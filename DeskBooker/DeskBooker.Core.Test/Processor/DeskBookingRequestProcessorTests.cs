using System;
using System.Collections.Generic;
using DeskBooker.Core.DataInterface;
using DeskBooker.Core.Domain;
using Moq;
using Xunit;

namespace DeskBooker.Core.Processor
{
    public class DeskBookingRequestProcessorTests
    {
        private readonly DeskBookingRequestProcessor _processor;
        private readonly DeskBookingRequest _request;
        private readonly List<Desk> _availableDesks;
        private readonly Mock<IDeskBookingRepository> _deskBookingRepositoryMock;
        private readonly Mock<IDeskRepository> _deskRepositoryMock;

        public DeskBookingRequestProcessorTests()
        {
             _request = new DeskBookingRequest
            {
                FirstName = "Murat",
                LastName = "İlgün",
                Email = "muratilgun34@gmail.com",
                Date = DateTime.Now
            };
             _availableDesks = new List<Desk> { new Desk() };
             _deskBookingRepositoryMock = new Mock<IDeskBookingRepository>();
             _deskRepositoryMock = new Mock<IDeskRepository>();
             _deskRepositoryMock.Setup(x => x.GetAvailableDesks(_request.Date)).Returns(_availableDesks);


             _processor = new DeskBookingRequestProcessor(_deskBookingRepositoryMock.Object,_deskRepositoryMock.Object);

        }
        
        [Fact]
        public void ShouldReturnDeskBookingResultWithRequestValues()
        {

            // Act
            DeskBookingResult result = _processor.BookDesk(_request);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(_request.FirstName,result.FirstName);
            Assert.Equal(_request.LastName,result.LastName);
            Assert.Equal(_request.Email,result.Email);
            Assert.Equal(_request.Date,result.Date);
        }
        
        [Fact]
        public void ShouldThrowExceptionIfRequestIsNull()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _processor.BookDesk(null));
            Assert.Equal("request",exception.ParamName);
        }
       
        [Fact]
        public void ShouldSaveDeskBooking()
        {
            DeskBooking saveDeskBooking = null;
            _deskBookingRepositoryMock.Setup(x => x.Save(It.IsAny<DeskBooking>()))
                .Callback<DeskBooking>(deskBooking =>
                {
                    saveDeskBooking = deskBooking;
                });
            _processor.BookDesk(_request);

            _deskBookingRepositoryMock.Verify(x=>x.Save(It.IsAny<DeskBooking>()),Times.Once);
            Assert.NotNull(saveDeskBooking);
            Assert.Equal(_request.FirstName,saveDeskBooking.FirstName);
            Assert.Equal(_request.LastName,saveDeskBooking.LastName);
            Assert.Equal(_request.Email,saveDeskBooking.Email);
            Assert.Equal(_request.Date,saveDeskBooking.Date);
        }

        [Fact]
        public void ShouldNotSaveDeskBookingIfNoDeskIsAvailable()
        {
            _availableDesks.Clear();
            _processor.BookDesk(_request);

            _deskBookingRepositoryMock.Verify(x => x.Save(It.IsAny<DeskBooking>()), Times.Never);
        }
    }
}

