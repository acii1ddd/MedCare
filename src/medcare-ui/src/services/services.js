
// получение всех улсуг, предоставляемых в данном филиале
export default async function GetServicesByBranch(branchName) {
    try {
        const response = await fetch(`https://localhost:7009/api/services/${branchName}`);
        const data = await response.json();
        return data;
    } catch (error) {
        console.error("Ошибка при загрузке услуг: ", error);
    }
}
