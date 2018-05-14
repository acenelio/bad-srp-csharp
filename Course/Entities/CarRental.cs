using System;

namespace Course.Entities {
    class CarRental {

        public string CarModel { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public Invoice Invoice { get; set; }
        public double PricePerHour { get; set; }
        public double PricePerDay { get; set; }

        public CarRental(string carModel, DateTime start, DateTime finish, double pricePerHour, double pricePerDay) {
            CarModel = carModel;
            Start = start;
            Finish = finish;
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
            Invoice = null;
        }

        public void ProcessInvoice() {

            TimeSpan duration = Finish.Subtract(Start);

            double basicPayment;
            if (duration.TotalHours <= 12.0) {
                basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours);
            }
            else {
                basicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);
            }

            double tax;
            if (basicPayment <= 100.00) {
                tax = basicPayment * 0.2;
            }
            else {
                tax = basicPayment * 0.15;
            }

            Invoice = new Invoice(basicPayment, tax);
        }

        public double TotalPayment() {
            return Invoice.BasicPayment + Invoice.Tax;
        }
    }
}
