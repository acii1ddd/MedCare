import { useState } from "react";
import { useLocation, useNavigate, useParams } from "react-router-dom";
import { Add } from "../../services/medicalRecords";

const MedicalRecordForm = () => {
    const { id } = useParams();
    const location = useLocation();
    const navigate = useNavigate();
    const currAppointmentid = location.state?.appointmentId; 

    const [formData, setFormData] = useState({
        diagnosis: "",
        treatment: "",
        description: "",
        appointmentId: currAppointmentid
    });

    const [errors, setErrors] = useState({});

    const handleChange = (e) => {
        // input name и value 
        const {name, value} = e.target;
        setFormData((prev) => (
            {...prev, [name]: value } // объект с измененным полем name на новое значение value
        ));
    }

    const handleSubmit = async (e) => {
        e.preventDefault();

        const newErrors = {};
        if (!formData.diagnosis.trim()) newErrors.diagnosis = "Обязательное поле";
        if (!formData.treatment.trim()) newErrors.treatment = "Обязательное поле";

        if (Object.keys(newErrors).length > 0) {
            setErrors(newErrors);
            console.warn("Введенные данные не прошли валидацию");
            return;
        }
        
        console.log("Данные отправлены ", formData);

        if (!formData.appointmentId) {
            alert("Не удалось добавить запись");
            return;
        }
        
        await Add(formData);
        alert("Запись успешно добавлена");
        navigate(`/med-card/${id}`, {
            state: {appointmentId: currAppointmentid}
        });
    }

    return (
        <form onSubmit={handleSubmit} className="max-w-md mx-auto p-6 bg-white rounded shadow text-left mt-15">
          <h2 className="text-xl font-bold text-blue-700 mb-4">Введите данные </h2>
            <div className="flex-1">
                <label className="block font-semibold text-left">
                    Диагноз <span className="text-red-600">*</span>
                </label>
                <input
                    type="text"
                    name="diagnosis"
                    placeholder="Введите диагноз"
                    value={formData.diagnosis}
                    onChange={handleChange}
                    className="w-full border border-gray-300 rounded p-2"
                />
                {errors.diagnosis && <p className="text-red-500 text-sm mt-1">{errors.diagnosis}</p>}
            </div>
            <div className="mb-4">
                <label className="block font-semibold text-left">
                    Лечение <span className="text-red-600">*</span>
                </label>
                <input
                    type="text"
                    name="treatment"
                    placeholder="Введите диагноз"
                    value={formData.treatment}
                    onChange={handleChange}
                    className="w-full border border-gray-300 rounded p-2"
                />
                {errors.treatment && <p className="text-red-500 text-sm mt-1">{errors.treatment}</p>}
            </div>
      
            <div className="mb-4">
                <label className="block font-semibold text-left">
                    Описание
                </label>
                <textarea
                    name="description"
                    placeholder="Введите описание"
                    value={formData.description}
                    onChange={handleChange}
                    rows="3"
                    className="w-full border border-gray-300 rounded p-2"
                />
            </div>
      
            <button
                type="submit"
                className="w-full bg-blue-600 hover:bg-blue-700 text-white font-semibold py-2 px-4 rounded"
            >
                Добавить
            </button>
        </form>
    );
}

export default MedicalRecordForm;