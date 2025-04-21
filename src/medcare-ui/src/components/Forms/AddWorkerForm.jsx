import { useEffect, useState } from "react";
import GetAllBranches from "../../services/branches";
import GetSpecializationsForBranch from "../../services/specializations";
import { Add } from "../../services/users/workers";
import { useNavigate } from "react-router-dom";

const AddWorkerForm = () => {
    const [branches, setBranches] = useState([]);
    const [specializations, setSpecializations] = useState([]);
    const [imageFile, setImageFile] = useState(null);

    const [formData, setFormData] = useState({
        login: "",
        password: "",
        userRole: "", // 0: Админ, 1: Доктор и т.д.

        userProfile: {
            firstName: "",
            lastName: "",
            patronymic: "",
            birthDate: "",
            gender: "",
            email: "",
            phoneNumber: "",
            image: "",
            passportSeries: "",
            passportNumber: ""
        },

        specializationId: "",
        branchId: ""
    });
    const navigate = useNavigate();

    useEffect(() => {
        const fetchBranches = async () => {
            const branches = await GetAllBranches();
            setBranches(branches);
        };

        fetchBranches();
    }, []);

    useEffect(() => {
        const fetchSpecializations = async () => {
            if (formData.branchId) {
                const specializations = await GetSpecializationsForBranch(formData.branchId);
                setSpecializations(specializations);
            } else {
                setSpecializations([]);
            }
        };

        fetchSpecializations();
    }, [formData.branchId]);

    const [errors, setErrors] = useState({});

    const handleChange = (e) => {
        // input name и value 
        const {name, value} = e.target;
        
        if (name.startsWith('userProfile.')) {
            const field = name.split('.')[1];
            
            setFormData((prev) => ({
                ...prev,
                userProfile: {
                    ...prev.userProfile,
                    [field]: value,
                },
            }));
        } else {
            setFormData((prev) => ({
                ...prev,
                [name]: value,
            }));
        }
    }

    const handleSubmit = async (e) => {
        e.preventDefault();

        const newErrors = {};

        if (!formData.login.trim()) newErrors.login = "Обязательное поле";
        if (!formData.password.trim()) newErrors.password = "Обязательное поле";
        if (!formData.userRole.trim()) newErrors.userRole = "Обязательное поле";
        
        if (!formData.userProfile.firstName.trim()) newErrors.firstName = "Обязательное поле";
        if (!formData.userProfile.lastName.trim()) newErrors.lastName = "Обязательное поле";
        if (!formData.userProfile.patronymic.trim()) newErrors.patronymic = "Обязательное поле";

        if (!formData.userProfile.birthDate.trim()) newErrors.birthDate = "Обязательное поле";
        if (!formData.userProfile.gender.trim()) newErrors.gender = "Обязательное поле";

        if (!formData.userProfile.email.trim()) newErrors.email = "Обязательное поле";
        if (!formData.userProfile.phoneNumber.trim()) newErrors.phoneNumber = "Обязательное поле";

        if (!formData.userProfile.passportSeries.trim()) newErrors.passportSeries = "Обязательное поле";
        if (!formData.userProfile.passportNumber.trim()) newErrors.passportNumber = "Обязательное поле";

        if (!formData.specializationId.trim()) newErrors.specializationId = "Обязательное поле";
        if (!formData.branchId.trim()) newErrors.branchId = "Обязательное поле";


        if (Object.keys(newErrors).length > 0) {
            setErrors(newErrors);
            console.warn("Введенные данные не прошли валидацию");
            return;
        }
        
        if (imageFile) {
            formData.userProfile.image = imageFile;
        }
        console.log("Данные отправлены ", formData);
        await Add(formData);
        navigate("/dashboard", {replace: true});
    }

    return (
        <form onSubmit={handleSubmit} className="max-w-md mx-auto p-6 bg-white rounded shadow text-left mt-15">
          <h2 className="text-xl font-bold text-blue-700 mb-4">ВВЕДИТЕ ДАННЫЕ СОТРУДНИКА</h2>
      
            <div className="mb-4">
                <label className="block font-semibold text-left">
                    Логин <span className="text-red-600">*</span>
                </label>
                <input
                    type="text"
                    name="login"
                    placeholder="Введите логин"
                    value={formData.login}
                    onChange={handleChange}
                    className="w-full border border-gray-300 rounded p-2"
                />
                {errors.login && <p className="text-red-500 text-sm mt-1">{errors.login}</p>}
            </div>
      
            <div className="mb-4">
                <label className="block font-semibold text-left">
                    Пароль <span className="text-red-600">*</span>
                </label>
                <input
                    type="text"
                    name="password"
                    placeholder="Введите пароль"
                    value={formData.password}
                    onChange={handleChange}
                    className="w-full border border-gray-300 rounded p-2"
                />
                {errors.password && <p className="text-red-500 text-sm mt-1">{errors.password}</p>}
            </div>
      
            <div className="mb-4">
                <label className="block font-semibold text-left">
                    Должность <span className="text-red-600">*</span>
                </label>
                <select
                    name="userRole"
                    value={formData.userRole}
                    onChange={handleChange}
                    className="w-full border border-gray-300 rounded p-2"
                >
                    <option value="">Выберите должность</option>
                    <option value="0">Доктор</option>
                </select>
                {errors.userRole && (
                    <p className="text-red-500 text-sm mt-1">{errors.userRole}</p>
                )}
            </div>
      
            <div className="mb-4">
                <label className="block font-semibold text-left">
                    Имя <span className="text-red-600">*</span>
                </label>
                <input
                    type="text"
                    name="userProfile.firstName"
                    placeholder="Введите имя"
                    value={formData.userProfile.firstName}
                    onChange={handleChange}
                    className="w-full border border-gray-300 rounded p-2"
                />
                {errors.firstName && <p className="text-red-500 text-sm mt-1">{errors.firstName}</p>}
            </div>
      
            <div className="mb-4">
                <label className="block font-semibold text-left">
                    Фамилия <span className="text-red-600">*</span>
                </label>
                <input
                    type="text"
                    name="userProfile.lastName"
                    placeholder="Введите фамилию"
                    value={formData.userProfile.lastName}
                    onChange={handleChange}
                    className="w-full border border-gray-300 rounded p-2"
                />
                {errors.lastName && <p className="text-red-500 text-sm mt-1">{errors.lastName}</p>}
            </div>
      
            <div className="mb-4">
                <label className="block font-semibold text-left">
                    Отчество <span className="text-red-600">*</span>
                </label>
                <input
                    type="text"
                    name="userProfile.patronymic"
                    placeholder="Введите отчество"
                    value={formData.userProfile.patronymic}
                    onChange={handleChange}
                    className="w-full border border-gray-300 rounded p-2"
                />
                {errors.patronymic && <p className="text-red-500 text-sm mt-1">{errors.patronymic}</p>}
            </div>
      
            <div className="mb-4">
                <label className="block font-semibold text-left">
                    Дата рождения <span className="text-red-600">*</span>
                </label>
                <input
                    type="date"
                    name="userProfile.birthDate"
                    value={formData.userProfile.birthDate}
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
                        name="userProfile.gender"
                        value="0"
                        checked={formData.userProfile.gender === '0'}
                        onChange={handleChange}
                        className="mr-2"
                    />
                        Жен
                    </label>
                    <label className="inline-flex items-center text-left">
                    <input
                        type="radio"
                        name="userProfile.gender"
                        value="1"
                        checked={formData.userProfile.gender === '1'}
                        onChange={handleChange}
                        className="mr-2"
                    />
                        Муж
                    </label>
                </div>
                {errors.gender && <p className="text-red-500 text-sm mt-1">{errors.gender}</p>}
            </div>

            <div className="mb-4">
                <label className="block font-semibold text-left">
                    Email <span className="text-red-600">*</span>
                </label>
                <input
                    type="email"
                    name="userProfile.email"
                    placeholder="Введите email"
                    value={formData.userProfile.email}
                    onChange={handleChange}
                    className="w-full border border-gray-300 rounded p-2"
                />
            </div>

            <div className="mb-4">
                <label className="block font-semibold text-left">
                    Телефон <span className="text-red-600">*</span>
                </label>
                <input
                    type="tel"
                    name="userProfile.phoneNumber"
                    placeholder="+375 (__) _______"
                    value={formData.userProfile.phoneNumber}
                    onChange={handleChange}
                    className="w-full border border-gray-300 rounded p-2"
                />
                {errors.phoneNumber && <p className="text-red-500 text-sm mt-1">{errors.phoneNumber}</p>}
            </div>

            <div className="mb-4">
                <label className="block font-semibold text-left">
                    Серия паспорта <span className="text-red-600">*</span>
                </label>
                <input
                    type="text"
                    name="userProfile.passportSeries"
                    placeholder="Введите серию паспорта"
                    value={formData.userProfile.passportSeries}
                    onChange={handleChange}
                    className="w-full border border-gray-300 rounded p-2"
                />
                {errors.passportSeries && <p className="text-red-500 text-sm mt-1">{errors.passportSeries}</p>}
            </div>

            <div className="mb-4">
                <label className="block font-semibold text-left">
                    Номер паспорта <span className="text-red-600">*</span>
                </label>
                <input
                    type="text"
                    name="userProfile.passportNumber"
                    placeholder="Введите номер паспорта"
                    value={formData.userProfile.passportNumber}
                    onChange={handleChange}
                    className="w-full border border-gray-300 rounded p-2"
                />
                {errors.passportNumber && <p className="text-red-500 text-sm mt-1">{errors.passportNumber}</p>}
            </div>

            <div className="mb-4">
                <label className="block font-semibold text-left">
                    Изображение
                </label>
                <input
                    type="file"
                    name="image"
                    accept="image/*"
                    onChange={(e) => setImageFile(e.target.files[0])}
                    className="w-full border border-gray-300 rounded p-2"
                />
            </div>

            {formData.userRole === "0" && (
                <div>
                    <div className="mb-4">
                        <label className="block font-semibold text-left">
                            Филиал <span className="text-red-600">*</span>
                        </label>
                        <select
                            name="branchId"
                            value={formData.branchId}
                            onChange={handleChange}
                            className="w-full border border-gray-300 rounded p-2"
                        >
                            <option value="">Выберите филиал</option>
                            {branches.map((branch) => {
                                return (
                                    <option key={branch.id} value={branch.id}>
                                        {branch.name}
                                    </option>
                                );
                            })}
                        </select>
                        {errors.branchId && <p className="text-red-500 text-sm mt-1">{errors.branchId}</p>}
                    </div>

                    <div className="mb-4">
                        <label className="block font-semibold text-left">
                            Специализация <span className="text-red-600">*</span>
                        </label>
                        <select
                            name="specializationId"
                            value={formData.specializationId}
                            onChange={handleChange}
                            className="w-full border border-gray-300 rounded p-2"
                        >
                            <option value="">Выберите специализацию</option>
                            {specializations.map((spec) => (
                                <option key={spec.id} value={spec.id}>
                                    {spec.name}
                                </option>
                            ))}
                        </select>
                        {errors.specializationId && <p className="text-red-500 text-sm mt-1">{errors.specializationId}</p>}
                    </div>
                </div>
            )}

            <button
                type="submit"
                className="w-full bg-blue-600 hover:bg-blue-700 text-white font-semibold py-2 px-4 rounded"
            >
                Добавить
            </button>
        </form>
    );
}

export default AddWorkerForm;