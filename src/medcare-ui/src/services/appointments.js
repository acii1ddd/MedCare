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

export { Add }