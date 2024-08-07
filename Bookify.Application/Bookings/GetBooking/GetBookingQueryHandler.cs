﻿using Bookify.Application.Abstractions.Authentication;
using Bookify.Application.Abstractions.Data;
using Bookify.Application.Abstractions.Messaging;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Bookings;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Application.Bookings.GetBooking
{
    internal sealed class GetBookingQueryHandler : IQueryHandler<GetBookingQuery, BookingResponse>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private readonly IUserContext _userContext;

        public GetBookingQueryHandler(ISqlConnectionFactory sqlConnectionFactory, IUserContext userContext)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
            _userContext = userContext;
        }

        public async Task<Result<BookingResponse>> Handle(GetBookingQuery request, CancellationToken cancellationToken)
        {
            using var connection = _sqlConnectionFactory.CreateConnection();

            const string sql = """
                SELECT
                    id AS Id,
                    apartment_id AS ApartmentId,
                    user_id AS UserId,
                    status AS Status,
                    price_for_period_amount AS PriceAmount,
                    price_for_period_currency AS PriceCurrency,
                    cleaning_fee_amount AS CleaningFeeAmount,
                    cleaning_fee_currency AS CleaningFeeCurrency,
                    amenities_up_charge_amount AS AmenitiesUpChargeAmount,
                    amenities_up_charge_currency AS AmenitiesUpChargeCurrency,
                    total_price_amount AS TotalPriceAmount,
                    total_price_currency AS TotalPriceCurrency,
                    duration_start AS DurationStart,
                    duration_end AS DurationEnd,
                    created_on_utc AS CreateOnUtc
                FROM bookings
                WHERE id = @BookingId
                """;

            var booking = await connection.QueryFirstOrDefaultAsync<BookingResponse>(
                sql,
                new
                {
                    request.BookingId
                });

            if (booking is null || booking.UserId != _userContext.UserId)
            {
                return Result.Failure<BookingResponse>(BookingErrors.NotFound);
            }

            return booking;
        }
    }
}
