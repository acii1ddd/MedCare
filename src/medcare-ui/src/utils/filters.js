const AppointmentFilter = Object.freeze({
    // предстоящие не пройденные
    Confirmed: "Confirmed",
    Completed: "Completed",
    Unpaid: "Unpaid",
    All: "All",
    Date: "Date"
});

const FilterAppoinements = (appointments, statusFilter, selectedDate) => {
    return appointments.filter((appointment) => {
        const visitDate = new Date(appointment.visitDate).toLocaleDateString("sv-SE");
        
        const appointmentStatus = appointment.appointmentStatus;
        const paymentStatus = appointment.paymentStatus;
      
        switch (statusFilter) {
          case AppointmentFilter.Confirmed:
            return appointmentStatus === AppointmentFilter.Confirmed;
          case AppointmentFilter.Completed:
            return appointmentStatus === AppointmentFilter.Completed;
          case AppointmentFilter.Unpaid:
            return paymentStatus === AppointmentFilter.Unpaid && appointmentStatus === AppointmentFilter.Completed;
          case AppointmentFilter.Date:
            return visitDate === selectedDate;
          default:
            return true;
        }
    });
};

export {AppointmentFilter, FilterAppoinements};