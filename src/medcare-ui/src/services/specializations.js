
// получение всех специализаций, услуги которых предоставляются в данном филиале
export default async function GetSpecializationsForBranch(branchId) {
    try {
        const response = await fetch(`https://localhost:7009/api/specializations/${branchId}`);
        const data = await response.json();
        return data;
    } catch (error) {
        console.error("Ошибка при загрузке специализаций: ", error);
    }
}
