const GetById = async (id) => {
    try {
        const response = await fetch(`https://localhost:7009/api/patients/${id}`);
        return await response.json();
    } catch (error) {
        console.error("Ошибка при получении пациента по Id: ", error);
        throw error;
    }
};

export {GetById}