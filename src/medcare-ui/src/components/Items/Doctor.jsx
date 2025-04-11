export default function Doctor({ doctor, onClick }) {
    return (
        <div className="doctor-card border p-4 rounded-lg shadow-lg max-w-xs mx-auto cursor-pointer hover:shadow-xl transition hover:bg-blue-100"
            onClick={() => onClick(doctor.id)}>
            <div className="doctor-image mb-4">
                {doctor.image ? (
                    <img 
                        src={doctor.image}
                        alt={`${doctor.firstName} ${doctor.lastName} ${doctor.Patronymic}`}
                        className="doctor-img w-full h-64 object-cover rounded-md"
                    />
                    ) : 
                    (
                        <p>Изображение не доступно</p>
                    )
                }
            </div>
            <div className="doctor-info text-center mb-4">
                <h2 className="text-2xl font-semibold">
                    {doctor.firstName} {doctor.lastName} {doctor.patronymic}
                </h2>
            </div>
            <div className="doctor-footer text-center text-lg text-gray-600">
                <h3>{doctor.specializationName}</h3>
            </div>
        </div>
    );
}
