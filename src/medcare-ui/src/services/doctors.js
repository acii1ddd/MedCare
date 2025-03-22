
// получение врачей определенного филиала
export default async function GetDoctorsByBranch(branchName) {
    try {
        const response = await fetch(`https://localhost:7009/api/doctors/${branchName}`);
        const data = await response.json();
    
        const doctorsWithImages = data.map(doctor => {
            let imageStartPart = "data:image/png;charset=utf-8;base64, "        
            doctor.image = imageStartPart + doctor.image;
            return doctor;
        });

        return doctorsWithImages;   
    } catch (error) {
        console.error("Ошибка при загрузке врачей: ", error);
    }
}
