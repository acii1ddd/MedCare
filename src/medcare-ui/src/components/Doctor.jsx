// изоюражение должно быть уже в base 64

// import { useEffect, useState } from "react"

export default function Doctor({ doctor }) {
    
    // imageBase64 - состояние, setImageBase64 - функция чтобы обновить состояние
    // const [imageBase64, setImageBase64] = useState("");
    
    // useEffect(() => {
    //     if (doctor.image && doctor.image.length > 0) {
    //         const byteArray = new Uint8Array(doctor.image);
    //         const blob = new Blob([byteArray], {type: "image/jpeg"});
    //         const reader = new FileReader();

    //         reader.onloadend = () => {
    //             setImageBase64(reader.result); // состояние изменилось -> компонент доктора перерендерится заново
    //         };

    //         reader.readAsDataURL(blob);
    //     }
    // }, [doctor.image]); // [doctor.image] deps — If present, effect will only activate if the values in the list change

    return (
        <div className="doctor-card border p-4 rounded-lg shadow-lg">
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
    )
}
