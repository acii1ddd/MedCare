const GetAllByPatient = async (patientId) => {
    try {
        const token = localStorage.getItem("token");

        const response = await fetch(`https://localhost:7009/api/medical-records/${patientId}`, {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Authorization": `bearer ${token}`
            }
        });
        const data = await response.json();
        return data;
    } catch (err) {
        console.err("Ошибка при получении записей в мед карте пациента ", err);
        throw err;
    }
}

const Add = async (medicalRecord) => {
    try {
        const token = localStorage.getItem("token");
        
        const response = await fetch("https://localhost:7009/api/medical-records", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Authorization": `bearer ${token}`
            },
            body: JSON.stringify(medicalRecord)
        });
        const data = await response.json();
        return data;
    } catch (err) {
        console.err("Ошибка при добавлении записи в мед карточку ", err);
        throw err;
    }
};

export {GetAllByPatient, Add};