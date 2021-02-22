import axios from 'axios';
import { baseUrl } from '../../config.json';

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

const numberEmployeeByKey = async(key) => {
    var res = await axios.get(baseUrl + 'Employee/numberEmployee/' + key);
    return res.data;
}

export default {
    getEmployee,
    numberEmployee,
    getEmployeeByKey,
    numberEmployeeByKey,
}