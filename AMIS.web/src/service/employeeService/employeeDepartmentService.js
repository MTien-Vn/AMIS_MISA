import axios from "axios"
import { baseUrl } from '../../config.json'

const getEmployeeDepartment = async() => {
    var res = await axios.get(baseUrl + 'EmployeeDepartment');
    return res.data;
}

export default {
    getEmployeeDepartment,
}