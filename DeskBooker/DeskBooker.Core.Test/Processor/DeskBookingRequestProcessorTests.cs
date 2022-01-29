using System;
using DeskBooker.Core.Domain;
using Xunit;

namespace DeskBooker.Core.Processor
{
    public class DeskBookingRequestProcessorTests
    {
        private readonly DeskBookingRequestProcessor _processor;

        public DeskBookingRequestProcessorTests()
        {
            _processor = new DeskBookingRequestProcessor();

        }
        [Fact]
        public void ShouldReturnDeskBookingResultWithRequestValues()
        {
            //Arrenge
            var request = new DeskBookingRequest
            {
                FirstName = "Murat",
                LastName = "İlgün",
                Email = "muratilgun34@gmail.com",
                Date = DateTime.Now
            };
            // Act
            DeskBookingResult result = _processor.BookDesk(request);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(request.FirstName,result.FirstName);
            Assert.Equal(request.LastName,result.LastName);
            Assert.Equal(request.Email,result.Email);
            Assert.Equal(request.Date,result.Date);
        }

        [Fact]
        public void ShouldThrowExceptionIfRequestIsNull()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _processor.BookDesk(null));
            Assert.Equal("request",exception.ParamName);
        }
    }
}

