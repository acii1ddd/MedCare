// получение врачей определенного филиала
export async function GetDoctorsByBranch(branchName) {
    try {
        const response = await fetch(`https://localhost:7009/api/doctors/${branchName}`);
        const data = await response.json();
        return GetDoctorsWithImages(data);
    } catch (error) {
        console.error("Ошибка при загрузке врачей филиала: ", error);
    }
}

export async function GetById(id) {
    try {
        const response = await fetch(`https://localhost:7009/api/doctors/${id}`);
        const doctor = await response.json();
        doctor.image = "data:image/png;charset=utf-8;base64, " + doctor.image;
        return doctor;
    } catch (error) {
        console.error("Ошибка при загрузке врачей филиала: ", error);
        throw error;
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
        console.error("Ошибка при загрузке врачей по фильтру: ", error);
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

export async function GetAvailableDaysForDoctor(doctorId, startDate, endDate) {
    if (!doctorId) {
        throw new Error("DoctorId неопределен");
    }
    try {
        let url = `https://localhost:7009/api/doctors/${doctorId}/available-days`;

        const params = new URLSearchParams();

        if (startDate && endDate) {
            params.append("startDate", startDate);
            params.append("endDate", endDate);
        }

        if (params.toString()) {
            url += "?" + params.toString();
        }

        const response = await fetch(url);
        const data = await response.json();
        
        const availableDays = data.days.map((d) => new Date(d));
        return availableDays;
    } catch (error) {
        console.error("Ошибка при загрузке свободных дней врача: ", error);
    }
}

export async function GetAvailableSlotsForDoctor(id, visitDate) {
    if (!id) throw new Error("Параметр id неопределен");
    if (!visitDate) throw new Error("Параметр visitDate неопределен");

    try {
        const response = await fetch(`https://localhost:7009/api/doctors/${id}/available-slots?visitDate=${visitDate.toLocaleDateString("sv-SE")}`);
        const data = await response.json();

        return data.slots.map(d => new Date(d));
    } catch (err) {
        console.error("Ошибка при загрузке свободных слотов на запись к врачу: ", err);
        throw err;
    }
}
