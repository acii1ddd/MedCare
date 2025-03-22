
// получение всех филиалов мед центра
export default async function GetAllBranches() {
    try {
        const response = await fetch(`https://localhost:7009/api/branches`);
        const branches = await response.json();
        return branches;   
    } catch (error) {
        console.error("Ошибка при загрузке филиалов: ", error);
    }
}
