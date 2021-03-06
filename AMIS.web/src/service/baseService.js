/**
 * 
 * @param {*} d 
 * định dạng thời gian theo dd/mm/yyyy
 * người tạo: Manh Tien (22/2/2021)
 */
function handleDate(d) {
    var date = new Date(d);
    var year = ("0000" + date.getFullYear()).slice(-4);
    var day = ("0" + date.getDate()).slice(-2);
    var month = ("0" + (date.getMonth() + 1)).slice(-2);
    return day + "/" + month + "/" + year;
}

/**
 * 
 * @param {*} d 
 * định dạng thời gian theo yyyy-mm-dd
 * người tạo: Manh Tien (22/2/2021)
 */
function handleDate2(d) {
    var date = new Date(d);
    var year = ("0000" + date.getFullYear()).slice(-4);
    var day = ("0" + date.getDate()).slice(-2);
    var month = ("0" + (date.getMonth() + 1)).slice(-2);
    return year + '-' + month + '-' + day;
}

/**
 * 
 * @param {*} money 
 * định dạng tiền VND
 * người tạo: Manh Tien (22/2/2021)
 */
function handleMoney(money) {
    if (money) {
        var num = parseFloat(money);
        return new Intl.NumberFormat().format(num);
    }
    return "";
}

/**
 * 
 * @param {*} genderCode 
 * định dạng giới tính 
 * người tạo: Manh Tien (22/2/2021)
 */
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

/**
 * 
 * @param {*} state 
 * định dạng trạng thái của tài khoản ngân hàng
 * người tạo: Manh Tien (22/2/2021)
 */
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
    handleState,
    handleDate2
}