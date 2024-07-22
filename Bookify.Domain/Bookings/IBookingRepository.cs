using Bookify.Domain.Apartments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Domain.Bookings
{
    public interface IBookingRepository
    {
        Task<Booking?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        Task<bool> IsOverlappingAsync(
            Apartment apartment,
            DateRange duration,
            CancellationToken cancellationToken);

        void Add(Booking booking);
    }
}
