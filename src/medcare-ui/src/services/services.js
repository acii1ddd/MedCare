// получение всех улсуг данной специализации, предоставляемых в данном филиале
export default async function GetServicesByBranch(branchId, specializationId) {
    try {
        const response = await fetch(`https://localhost:7009/api/services/${branchId}/services?specializationId=${specializationId}`);
        return await response.json();
    } catch (error) {
        console.error("Ошибка при загрузке услуг: ", error);
        throw error;
    }
}
