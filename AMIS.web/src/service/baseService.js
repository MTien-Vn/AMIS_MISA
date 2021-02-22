function handleDate(d) {
    var date = new Date(d);
    var year = ("0000" + date.getFullYear()).slice(-4);
    var day = ("0" + date.getDate()).slice(-2);
    var month = ("0" + (date.getMonth() + 1)).slice(-2);
    return day + "/" + month + "/" + year;
}

function handleMoney(money) {
    if (money) {
        var num = parseFloat(money);
        return new Intl.NumberFormat().format(num);
    }
    return "";
}

function handleGender(genderCode) {
    switch (genderCode) {
        case 0:
            return "Nam";
        case 1:
            return "Nữ";
        case 2:
            return "Khác";
    }
}

function handleState(state) {
    switch (state) {
        case 0:
            return "Ngưng hoạt động";
        case 1:
            return "Hoạt động";
    }
}

export default {
    handleDate,
    handleMoney,
    handleGender,
    handleState
}