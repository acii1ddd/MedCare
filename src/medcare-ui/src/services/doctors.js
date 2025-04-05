
// получение врачей определенного филиала
export async function GetDoctorsByBranch(branchName) {
    try {
        const response = await fetch(`https://localhost:7009/api/doctors/${branchName}`);
        const data = await response.json();
        return GetDoctorsWithImages(data);
    } catch (error) {
        console.error("Ошибка при загрузке врачей: ", error);
    }
}

export async function GetDoctorsByBranchWithSpecializationFilter(branchName, specializationId) {
    try {
        const query = specializationId 
            ? `?specializationId=${encodeURIComponent(specializationId)}`
            : ""
            
        const response = await fetch(`https://localhost:7009/api/doctors/${branchName}${query}`);
        const data = await response.json();
        return GetDoctorsWithImages(data);
    } catch (error) {
        console.error("Ошибка при загрузке врачей: ", error);
    }
}

const GetDoctorsWithImages = (data) => {
    const doctorsWithImages = data.map(doctor => {
        let imageStartPart = "data:image/png;charset=utf-8;base64, "
        doctor.image = imageStartPart + doctor.image;
        return doctor;
    });

    return doctorsWithImages;
}