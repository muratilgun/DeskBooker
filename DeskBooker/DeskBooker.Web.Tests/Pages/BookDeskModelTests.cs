﻿using DeskBooker.Core.Domain;
using DeskBooker.Core.Processor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace DeskBooker.Web.Pages
{
    public class BookDeskModelTests
    {
        private readonly Mock<IDeskBookingRequestProcessor> _processorMock;
        private readonly BookDeskModel _bookDeskModel;
        private readonly DeskBookingResult _deskBookingResult;

        public BookDeskModelTests()
        { 
            _processorMock = new Mock<IDeskBookingRequestProcessor>();

           _bookDeskModel = new BookDeskModel(_processorMock.Object)
            {
                DeskBookingRequest = new DeskBookingRequest()
            };
            _deskBookingResult = new DeskBookingResult
            {
                Code = DeskBookingResultCode.Success
            };

            _processorMock.Setup(x => x.BookDesk(_bookDeskModel.DeskBookingRequest)).Returns(_deskBookingResult);
        }
        [Theory]
        [InlineData(1, true)]
        [InlineData(0, false)]
        public void ShouldCallBookDeskMethodOfProcessorIfModelIsValid(int expectedBookDeskCalls, bool isModelValid)
        {
            if (!isModelValid)
            {
                _bookDeskModel.ModelState.AddModelError("JustAKey", "AnErrorMessage");
            }

            _bookDeskModel.OnPost();

            _processorMock.Verify(z => z.BookDesk(_bookDeskModel.DeskBookingRequest), Times.Exactly(expectedBookDeskCalls));
        }

        [Fact]
        public void ShouldAddModelErrorIfNoDeskIsAvailable()
        {

            _deskBookingResult.Code = DeskBookingResultCode.NoDeskAvailable;

            _bookDeskModel.OnPost();

            var modelStateEntry = Assert.Contains("DeskBookingRequest.Date", _bookDeskModel.ModelState);
            var modelError = Assert.Single(modelStateEntry.Errors);
            Assert.Equal("No desk available for selected date",modelError.ErrorMessage);
        }

        [Fact]
        public void ShouldNotAddErrorIfDeskIsAvailable()
        {
            _deskBookingResult.Code = DeskBookingResultCode.Success;

            _bookDeskModel.OnPost();

            Assert.DoesNotContain("DeskBookingRequest.Date", _bookDeskModel.ModelState);
        }
    }
}