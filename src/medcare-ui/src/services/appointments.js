const Add = async (appointmentData) => {
    try {
        const token = localStorage.getItem("token");
        
        const response = await fetch("https://localhost:7009/api/appointments", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Authorization": `bearer ${token}`
            },
            body: JSON.stringify(appointmentData)
        });
        const data = await response.json();
        return data;
    } catch (err) {
        console.err("Ошибка при добавлении записи на прием ", err);
        throw err;
    }
};

const GetAllForPatient = async (patientId) => {
    try {
        const token = localStorage.getItem("token");

        const response = await fetch(`https://localhost:7009/api/appointments?patientId=${patientId}`, {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Authorization": `bearer ${token}`
            }
        });
        const data = await response.json();
        return data;
    } catch (err) {
        console.err("Ошибка при получении записей о приемах пациентов ", err);
        throw err;
    }
};

const GetAllForDoctor = async (doctorId) => {
    try {
        const token = localStorage.getItem("token");

        const response = await fetch(`https://localhost:7009/api/appointments?doctorId=${doctorId}`, {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Authorization": `bearer ${token}`
            }
        });
        const data = await response.json();
        return data;
    } catch (err) {
        console.err("Ошибка при получении записей о приемах для доктора ", err);
        throw err;
    }
};

const GetAll = async () => {
    try {
        const token = localStorage.getItem("token");

        const response = await fetch(`https://localhost:7009/api/appointments`, {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Authorization": `bearer ${token}`
            }
        });
        const data = await response.json();
        return data;
    } catch (err) {
        console.err("Ошибка при получении всех записей о приемах ", err);
        throw err;
    }
};

const CompleteAppointment = async (appointmentId) => {
    try {
        const token = localStorage.getItem("token");

        const response = await fetch(`https://localhost:7009/api/appointments/${appointmentId}/complete`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Authorization": `bearer ${token}`
            }
        });
        
        if (response.status != 200) {
            throw new Error("Ошибка при установке приема на 'Пройденный'");
        }
    } catch (err) {
        console.err(err);
        throw err;
    }
};

const MarkAsPaid = async (appointmentId) => {
    try {
        const token = localStorage.getItem("token");

        const response = await fetch(`https://localhost:7009/api/appointments/${appointmentId}/pay`, {
            method: "POST",
            headers: {
                "Authorization": `bearer ${token}`
            }
        });
        
        if (response.status != 200) {
            console.warn("Ошибка при установке статуса оплаты на 'Оплачен'");
            return false;
        }
        return true;
    } catch (err) {
        console.err(err);
        throw err;
    }
};

export { Add, GetAllForPatient, GetAllForDoctor, CompleteAppointment, GetAll, MarkAsPaid }