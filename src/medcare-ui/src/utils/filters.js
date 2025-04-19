const AppointmentFilter = Object.freeze({
    // предстоящие не пройденные
    Confirmed: "Confirmed",
    Completed: "Completed",
    All: "All",
    Date: "Date"
});

const FilterAppoinements = (appointments, statusFilter, selectedDate) => {
    return appointments.filter((appointment) => {
        const visitDate = new Date(appointment.visitDate).toLocaleDateString("sv-SE");
        const status = appointment.appointmentStatus;
      
        switch (statusFilter) {
          case AppointmentFilter.Confirmed:
            return status === AppointmentFilter.Confirmed;
          case AppointmentFilter.Completed:
            return status === AppointmentFilter.Completed;
          case AppointmentFilter.Date:
            return visitDate === selectedDate;
          default:
            return true;
        }
    });
};

export {AppointmentFilter, FilterAppoinements};