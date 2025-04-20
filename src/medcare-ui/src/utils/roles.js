const getRole = (role) => {
    return roleMap[role] || "Неизвестная должность";
};

const roleMap = {
    Doctor: "Врач",
    Receptionist: "Регистратор",
    Director: "Директор"
};

export default getRole;