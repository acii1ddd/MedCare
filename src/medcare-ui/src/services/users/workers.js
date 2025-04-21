const GetAll = async () => {
    try {
        const response = await fetch(`https://localhost:7009/api/workers`);
        return await response.json();
    } catch (error) {
        console.error("Ошибка при загрузке сотрудников: ", error);
        throw error;
    }
};

const Add = async (workerData) => {
    const formData = new FormData();

    formData.append("Login", workerData.login);
    formData.append("Password", workerData.password);
    formData.append("UserRole", Number(workerData.userRole));

    formData.append("SpecializationId", workerData.specializationId);
    formData.append("BranchId", workerData.branchId);

    // userProfile
    formData.append("UserProfile.FirstName", workerData.userProfile.firstName);
    formData.append("UserProfile.LastName", workerData.userProfile.lastName);
    formData.append("UserProfile.Patronymic", workerData.userProfile.patronymic);
    formData.append("UserProfile.BirthDate", new Date(workerData.userProfile.birthDate).toISOString());
    formData.append("UserProfile.Gender", Number(workerData.userProfile.gender));
    formData.append("UserProfile.Email", workerData.userProfile.email);
    formData.append("UserProfile.PhoneNumber", workerData.userProfile.phoneNumber);
    formData.append("UserProfile.PassportSeries", workerData.userProfile.passportSeries);
    formData.append("UserProfile.PassportNumber", workerData.userProfile.passportNumber);

    if (workerData.userProfile.image) {
        formData.append("UserProfile.Image", workerData.userProfile.image);
    }

    try {
        const token = localStorage.getItem("token");
        
        await fetch("https://localhost:7009/api/workers", {
            method: "POST",
            headers: {
                "Authorization": `bearer ${token}`
            },
            body: formData
        });
    } catch (err) {
        console.err("Ошибка при добавлении сотрудника ", err);
        throw err;
    }
};

const Delete = async (id) => {
    try {
        const token = localStorage.getItem("token");

        const response = await fetch(`https://localhost:7009/api/workers/${id}`, {
            method: "DELETE",
            headers: {
                "Authorization": `bearer ${token}`
            }
        });
        return response.status != 200 ? false : true;
    } catch (error) {
        console.error("Ошибка при удалении сотрудника: ", error);
        throw error;
    }
};

export {GetAll, Add, Delete};