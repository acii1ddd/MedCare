const genderToString = (gender) => {
    if (gender === 0) return "Мужской";
    if (gender === 1) return "Женский";
    return "Неизвестно";
};

export {genderToString};