const isEqual = (d1, d2) => {
    if (!d1) return false;
    if (!d2) return false;

    return (
        d1.getDate() === d2.getDate() &&
        d1.getMonth() === d2.getMonth() &&
        d1.getFullYear() === d2.getFullYear()
    );
}

const isEqualWithTime = (d1, d2) => {
    if (!d1) return false;
    if (!d2) return false;

    return (
        d1.getDate() === d2.getDate() &&
        d1.getMonth() === d2.getMonth() &&
        d1.getFullYear() === d2.getFullYear() &&
        d1.getHours() === d2.getHours() &&
        d1.getMinutes() === d2.getMinutes()
    );
}

export {isEqual, isEqualWithTime};