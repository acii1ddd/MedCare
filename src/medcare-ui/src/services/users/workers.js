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
    workerData.userProfile.birthDate = new Date(workerData.userProfile.birthDate).toISOString();
    workerData.userProfile.gender = Number(workerData.userProfile.gender);
    workerData.userRole = Number(workerData.userRole);
    try {
        const token = localStorage.getItem("token");
        
        const response = await fetch("https://localhost:7009/api/workers", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Authorization": `bearer ${token}`
            },
            body: JSON.stringify(workerData)
        });
        if(response.status != 200) {
            throw new Error("Ошибка при добавлении сотрудника");
        }
    } catch (err) {
        console.err("Ошибка при добавлении сотрудника ", err);
        throw err;
    }
};

export {GetAll, Add};