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
      [Fact]
      public void ShouldCallBookDeskMethodOfProcessor()
      {
          var processorMock = new Mock<IDeskBookingRequestProcessor>();

          var bookDeskModel = new BookDeskModel(processorMock.Object)
          {
              DeskBookingRequest = new DeskBookingRequest()
          };

          bookDeskModel.OnPost();
          processorMock.Verify(z=> z.BookDesk(bookDeskModel.DeskBookingRequest),Times.Once);
      }
  }
}
