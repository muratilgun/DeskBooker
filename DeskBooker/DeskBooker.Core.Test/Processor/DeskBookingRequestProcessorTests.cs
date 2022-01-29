using System;
using DeskBooker.Core.Domain;
using Xunit;

namespace DeskBooker.Core.Processor
{
    public class DeskBookingRequestProcessorTests
    {
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
            var processor = new DeskBookingRequestProcessor();
            // Act
            DeskBookingResult result = processor.BookDesk(request);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(request.FirstName,result.FirstName);
            Assert.Equal(request.LastName,result.LastName);
            Assert.Equal(request.Email,result.Email);
            Assert.Equal(request.Date,result.Date);
        }
    }
}