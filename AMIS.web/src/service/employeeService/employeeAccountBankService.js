import axios from "axios"
import { baseUrl } from '../../config.json'

const getEmployeeBankByEmployeeId = async(id) => {
    var res = await axios.get(baseUrl + 'EmployeeAccountBank/list/' + id);
    return res.data;
}

const deleteEmployeeAccountBank = async(bankAccountId) => {
    var res = await axios.delete(baseUrl + 'EmployeeAccountBank/' + bankAccountId);
    return res.data;
}

export default {
    getEmployeeBankByEmployeeId,
    deleteEmployeeAccountBank,
}