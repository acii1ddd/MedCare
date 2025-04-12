export default function DoctorSelector({ doctors, selectedDoctor, setSelectedDoctor }) {
    return (
      <>
        <label className="block font-bold">Специалист:</label>
        <select
          value={selectedDoctor?.id || ""}
          onChange={(e) =>
            setSelectedDoctor(doctors.find((d) => d.id == e.target.value))
          }
          className="w-full p-2 border rounded mb-4"
        >
          <option value="" disabled>Выберите врача</option>
          {doctors.map((doctor) => (
            <option key={doctor.id} value={doctor.id}>
              {doctor.firstName} {doctor.lastName} {doctor.patronymic}
            </option>
          ))}
        </select>
      </>
    );
}
