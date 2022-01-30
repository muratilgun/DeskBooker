using DeskBooker.Core.Domain;
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
      [Theory]
      [InlineData(1,true)]
      [InlineData(0,false)]
      public void ShouldCallBookDeskMethodOfProcessorIfModelIsValid(int expectedBookDeskCalls,bool isModelValid)
      {
          var processorMock = new Mock<IDeskBookingRequestProcessor>();

          var bookDeskModel = new BookDeskModel(processorMock.Object)
          {
              DeskBookingRequest = new DeskBookingRequest()
          };
          if (!isModelValid)
          {
              bookDeskModel.ModelState.AddModelError("JustAKey","AnErrorMessage");
          }
          bookDeskModel.OnPost();
          processorMock.Verify(z=> z.BookDesk(bookDeskModel.DeskBookingRequest),Times.Exactly(expectedBookDeskCalls));
      }
  }
}
