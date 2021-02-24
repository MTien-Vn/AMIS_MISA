import axios from 'axios';
import { baseUrl } from '../../config.json';

/**
 * @param {any} email
 * vaidate email
 */
const isEmail = (email) => {
    var regex = /^([a-zA-Z0-9_.+-@])+(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(email);
}

/**
 * @param {any} employeeCode
 * @param {any} employeeName
 * @param {any} employeeIDCard
 * @param {any} email
 * @param {any} phoneNumber
 * validate required field
 */
const validate = (employee) => {
    var checks = [false, false, false, false];
    if (!employee.EmployeeCode) {
        checks[0] = true;
    }
    if (!employee.EmployeeName) {
        checks[1] = true;
    }
    if (!employee.EmployeeDepartmentId) {
        checks[2] = true;
    }
    if (employee.Email) {
        if (!isEmail(employee.Email)) {
            checks[3] = true;
        }
    }
    return checks;
}

const getEmployeeById = async(id) => {
    var res = await axios.get(baseUrl + 'Employee/' + id);
    return res.data;
}

const getEmployee = async(page, limmit) => {
    var res = await axios.get(baseUrl + 'Employee/' + page + '/' + limmit);
    return res.data;
}

const numberEmployee = async() => {
    var res = await axios.get(baseUrl + 'Employee/numberEntity');
    return res.data;
}

const getEmployeeByKey = async(key, page, limmit) => {
    var res = await axios.get(baseUrl + 'Employee/' + 'filter/' + key + '/' + page + '/' + limmit);
    return res.data;
}

const getEmployeeByEmployeeCode = async(code) => {
    var res = await axios.get(baseUrl + 'Employee/getEmployeeByEmployeeCode/' + code);
    return res.data;
}

const numberEmployeeByKey = async(key) => {
    var res = await axios.get(baseUrl + 'Employee/numberEmployee/' + key);
    return res.data;
}

const getEmployeeCodeMax = async() => {
    var res = await axios.get(baseUrl + 'Employee/employeeCodeMax');
    var employeeCode = res.data;
    var letterPath = employeeCode.slice(0, 2);
    var digitPath = employeeCode.slice(-5);
    digitPath = parseInt(digitPath) + 1;
    return letterPath + digitPath;
}

const saveEmployee = async(employeeModel) => {
    if (employeeModel.Employee.EmployeeId === '') {
        var res = await axios.post(baseUrl + 'Employee/saveEmployee', employeeModel);
        return res.data;
    } else {
        var respone = await axios.put(baseUrl + 'Employee/updateEmployee', employeeModel);
        return respone.data;
    }

}


const deleteEmployeeByCode = async(code) => {
    var res = await axios.delete(baseUrl + 'Employee/' + code);
    return res.data;
}

const deleteEmployeeById = async(id) => {
    var res = await axios.delete(baseUrl + 'Employee/ById' + id);
    return res.data;
}

export default {
    getEmployeeById,
    getEmployee,
    numberEmployee,
    getEmployeeByKey,
    numberEmployeeByKey,
    saveEmployee,
    deleteEmployeeByCode,
    deleteEmployeeById,
    getEmployeeByEmployeeCode,
    validate,
    getEmployeeCodeMax,
}