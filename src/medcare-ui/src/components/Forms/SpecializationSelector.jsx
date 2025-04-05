export default function SpecializationSelector({ specializations, selectedSpecialization, setSelectedSpecialization }) {
    return (
      <>
        <label className="block font-bold">Специализация врача:</label>
        <select
          value={selectedSpecialization?.id || ""} // если specialization - пустой айтем
          onChange={(e) => {
            const selectedId = e.target.value;
            const specialization = specializations.find(s => s.id === selectedId);
            setSelectedSpecialization(specialization)}
          }
          
          className="w-full p-2 border rounded mb-4"
        >
          {
            specializations.map((specialization) => (
                <option key={specialization.id} value={specialization.id}>
                    {specialization.name}
                </option>
            ))
          }
        </select>
      </>
    );
  }
  