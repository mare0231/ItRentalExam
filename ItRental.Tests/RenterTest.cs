using ItRental.Entities;
using System;
using System.Collections.Generic;
using Xunit;

namespace ItRental.Tests
{
    public class RenterTest
    {
        [Fact]
        public void NextRentalDue_ReturnsNullWithNoRentals()
        {
            Renter renter = new Renter() { Rentals = new List<Rental>() };
            Rental actual = renter.NextRentalDue();
            Assert.Null(actual);
        }
        [Fact]
        public void NextRentalDue_ReturnsCorrectRental()
        {
            Renter renter = new Renter() { Rentals = new List<Rental>() { new Rental() { ReturnTime = DateTime.Now.AddDays(1) }, new Rental() { ReturnTime = DateTime.Now.AddDays(2) }, new Rental() { ReturnTime = DateTime.Now.AddDays(3) } } };
            Rental expected = renter.Rentals[0];
            Rental actual = renter.NextRentalDue();
            Assert.Same(expected, actual);
        }
        [Fact]
        public void GotOverdueRental_ReturnsFalseWithNoRentals()
        {
            Renter renter = new Renter() { Rentals = new List<Rental>() };
            bool actual = renter.GotOverdueRental();
            Assert.False(actual);
        }
        [Fact]
        public void GotOverdueRental_ReturnsFalseWithRentals()
        {
            Renter renter = new Renter() { Rentals = new List<Rental>() { new Rental() { ReturnTime = DateTime.Now.AddDays(1) } } };
            bool actual = renter.GotOverdueRental();
            Assert.False(actual);
        }
        [Fact]
        public void GotOverdueRental_ReturnsTrueWithOverdueRentals()
        {
            Renter renter = new Renter() { Rentals = new List<Rental>() { new Rental() { ReturnTime = DateTime.Now.AddDays(-1) } } };
            bool actual = renter.GotOverdueRental();
            Assert.True(actual);
        }
    }
}
