const AppointmentFilter = Object.freeze({
    // предстоящие не пройденные
    Confirmed: "Confirmed",
    Completed: "Completed",
    Unpaid: "Unpaid", // Unpaid and Completed
    Paid: "Paid", // Paid and Complete
    All: "All",
    Date: "Date"
});

const FilterAppoinements = (appointments, statusFilter, selectedDate) => {
  let filtered = [...appointments];
  
  if (statusFilter === AppointmentFilter.Unpaid) {
    filtered = filtered.filter(a => a.appointmentStatus === AppointmentFilter.Completed && a.paymentStatus === AppointmentFilter.Unpaid);
  } 
  else if (statusFilter === AppointmentFilter.Paid) {
      filtered = filtered.filter(a => a.appointmentStatus === AppointmentFilter.Completed && a.paymentStatus === AppointmentFilter.Paid); 
  }
  else if (statusFilter === AppointmentFilter.Confirmed) {
    filtered = filtered.filter(a => a.appointmentStatus === AppointmentFilter.Confirmed); 
  }
  else if (statusFilter === AppointmentFilter.Completed) {
    filtered = filtered.filter(a => a.appointmentStatus === AppointmentFilter.Completed); 
  }

  if (selectedDate) {
      filtered = filtered.filter(a => new Date(a.visitDate).toLocaleDateString("sv-SE") === selectedDate);
  }

  return filtered;
}  
// const FilterAppoinements = (appointments, statusFilter, selectedDate) => {
//     return appointments.filter((appointment) => {
//         const visitDate = new Date(appointment.visitDate).toLocaleDateString("sv-SE");
        
//         const appointmentStatus = appointment.appointmentStatus;
//         const paymentStatus = appointment.paymentStatus;
      
//         switch (statusFilter) {
//           case AppointmentFilter.Confirmed:
//             return appointmentStatus === AppointmentFilter.Confirmed;
//           case AppointmentFilter.Completed:
//             return appointmentStatus === AppointmentFilter.Completed;
//           case AppointmentFilter.Unpaid:
//             return paymentStatus === AppointmentFilter.Unpaid && appointmentStatus === AppointmentFilter.Completed;
//           case AppointmentFilter.Paid:
//             return paymentStatus === AppointmentFilter.Paid && appointmentStatus === AppointmentFilter.Completed;
//           case AppointmentFilter.Date:
//             return visitDate === selectedDate;
//           default:
//             return true;
//         }
//     });
// };

export {AppointmentFilter, FilterAppoinements};