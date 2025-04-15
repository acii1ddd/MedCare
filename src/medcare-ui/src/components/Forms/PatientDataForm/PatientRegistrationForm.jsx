import { useState } from "react";

const PatientForm = () => {
    const [formData, setFormData] = useState({
        lastName: "",
        firstName: "",
        patronymic: "",
        birthDate: "",
        gender: "",
        phoneNumber: "",
        email: "",
        note: ""
    });

    const [errors, setErrors] = useState({});

    const handleChange = (e) => {
        // input name и value 
        const {name, value} = e.target;
        setFormData((prev) => (
            {...prev, [name]: value } // объект с измененным полем name на новое значение value
        ));
    }

    const handleSubmit = (e) => {
        e.preventDefault();

        const newErrors = {};
        if (!formData.lastName.trim()) newErrors.lastName = "Обязательное поле";
        if (!formData.firstName.trim()) newErrors.firstName = "Обязательное поле";
        if (!formData.patronymic.trim()) newErrors.patronymic = "Обязательное поле";
        if (!formData.birthDate.trim()) newErrors.birthDate = "Обязательное поле";
        if (!formData.gender.trim()) newErrors.gender = "Обязательное поле";
        if (!formData.phoneNumber.trim()) newErrors.phoneNumber = "Обязательное поле";
        
        if (Object.keys(newErrors).length > 0) {
            setErrors(newErrors);
            console.warn("Введенные данные не прошли валидацию");
            return;
        }
        
        console.log("Данные отправлены ", formData);
    }

    return (
        <form onSubmit={handleSubmit} className="max-w-md mx-auto p-6 bg-white rounded shadow text-left">
          <h2 className="text-xl font-bold text-blue-700 mb-4">ВАШИ ДАННЫЕ</h2>
      
            <div className="mb-4">
                <label className="block font-semibold text-left">
                    Фамилия <span className="text-red-600">*</span>
                </label>
                <input
                    type="text"
                    name="lastName"
                    value={formData.lastName}
                    onChange={handleChange}
                    className="w-full border border-gray-300 rounded p-2"
                />
                {errors.lastName && <p className="text-red-500 text-sm mt-1">{errors.lastName}</p>}
            </div>
      
            <div className="mb-4">
                <label className="block font-semibold text-left">
                    Имя <span className="text-red-600">*</span>
                </label>
                <input
                    type="text"
                    name="firstName"
                    value={formData.firstName}
                    onChange={handleChange}
                    className="w-full border border-gray-300 rounded p-2"
                />
                {errors.firstName && <p className="text-red-500 text-sm mt-1">{errors.firstName}</p>}
            </div>
      
            <div className="mb-4">
                <label className="block font-semibold text-left">
                    Отчество
                </label>
                <input
                    type="text"
                    name="patronymic"
                    value={formData.patronymic}
                    onChange={handleChange}
                    className="w-full border border-gray-300 rounded p-2"
                />
                {errors.patronymic && <p className="text-red-500 text-sm mt-1">{errors.patronymic}</p>}
            </div>

            <div className="mb-4 flex gap-4">
                <div className="flex-1">
                    <label className="block font-semibold text-left">
                        Дата рождения <span className="text-red-600">*</span>
                    </label>
                    <input
                        type="date"
                        name="birthDate"
                        value={formData.birthDate}
                        onChange={handleChange}
                        className="w-full border border-gray-300 rounded p-2"
                    />
                    {errors.birthDate && <p className="text-red-500 text-sm mt-1">{errors.birthDate}</p>}
                </div>
      
                <div className="flex-1">
                    <label className="block font-semibold text-left">
                        Пол <span className="text-red-600">*</span>
                    </label>
                    <div className="flex items-center gap-4 mt-2">
                        <label className="inline-flex items-center text-left">
                        <input
                            type="radio"
                            name="gender"
                            value="Жен"
                            checked={formData.gender === 'Жен'}
                            onChange={handleChange}
                            className="mr-2"
                        />
                            Жен
                        </label>
                        <label className="inline-flex items-center text-left">
                        <input
                            type="radio"
                            name="gender"
                            value="Муж"
                            checked={formData.gender === 'Муж'}
                            onChange={handleChange}
                            className="mr-2"
                        />
                            Муж
                        </label>
                    </div>
                    {errors.gender && <p className="text-red-500 text-sm mt-1">{errors.gender}</p>}
                </div>
        </div>
      
        <div className="mb-4">
            <label className="block font-semibold text-left">
                Телефон <span className="text-red-600">*</span>
            </label>
            <input
                type="tel"
                name="phone"
                placeholder="+375 (__) _______"
                value={formData.phone}
                onChange={handleChange}
                className="w-full border border-gray-300 rounded p-2"
            />
              {errors.phoneNumber && <p className="text-red-500 text-sm mt-1">{errors.phoneNumber}</p>}
        </div>
      
        <div className="mb-4">
            <label className="block font-semibold text-left">
                Email
            </label>
            <input
                type="email"
                name="email"
                value={formData.email}
                onChange={handleChange}
                className="w-full border border-gray-300 rounded p-2"
            />
        </div>
      
        <div className="mb-4">
            <label className="block font-semibold text-left">
                Примечание
            </label>
            <textarea
                name="note"
                value={formData.note}
                onChange={handleChange}
                rows="3"
                className="w-full border border-gray-300 rounded p-2"
            />
        </div>
      
            <button
            type="submit"
            className="w-full bg-blue-600 hover:bg-blue-700 text-white font-semibold py-2 px-4 rounded"
          >
                Записаться
            </button>
        </form>
    );
}

export default PatientForm;