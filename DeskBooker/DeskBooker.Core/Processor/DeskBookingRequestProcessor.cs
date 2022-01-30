﻿using DeskBooker.Core.Domain;
using System;
using DeskBooker.Core.DataInterface;

namespace DeskBooker.Core.Processor
{
    public class DeskBookingRequestProcessor
    {
        public DeskBookingRequestProcessor(IDeskBookingRepository deskBookingRepository)
        {
        }

        public DeskBookingResult BookDesk(DeskBookingRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            return new DeskBookingResult
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Date = request.Date,

            };
        }
    }
}