<template>
    <div>
        <div class="dialog" :class="{hideFormClass: isHide}">
        <div class="dialog-modal"></div>
        <div class="container">
            <div class="header-dialog">
                <div class="header-dialog-text">Thông tin nhân viên</div>
                <div class="btn-close" @click="handleCloseForm"></div>
            </div>
            <div class="body-dialog">
                <div class="content-dialog">
                    <div class="general">
                        <div class="general-left">
                            <div class="code-name">
                                <div class="employeeCode">
                                    <div>
                                        <label>Mã</label>
                                        <span class="require-charecter">*</span>
                                        <span class="require-charecter" v-if="checkRequiredField[0] === true">Không được trống</span>
                                    </div>
                                    <div><input type="text" v-model="employeeModel.Employee.EmployeeCode" ref="employeeCode"/></div>
                                </div>
                                <div class="employeeName">
                                    <div>
                                        <label>Tên</label>
                                        <span class="require-charecter">*</span>
                                        <span class="require-charecter" v-if="checkRequiredField[1] === true">Không được trống</span>
                                    </div>
                                    <div><input type="text" v-model="employeeModel.Employee.EmployeeName" /></div>
                                </div>
                            </div>
                            <div class="department">
                                <div>
                                    <label>Đơn vị</label>
                                    <span class="require-charecter">*</span>
                                    <span class="require-charecter" v-if="checkRequiredField[2] === true">Không được trống</span>
                                </div>
                                <div><select v-model="employeeModel.Employee.EmployeeDepartmentId">
                                        <option v-for="employeeDer in employeeDepartmentList"
                                        :key="employeeDer.EmployeeDepartmentId"
                                        :value="employeeDer.EmployeeDepartmentId">
                                        {{employeeDer.EmployeeDepartmentName}}
                                        </option>
                                    </select>
                                </div>
                            </div>
                            <div class="position">
                                <div><label>Chức danh</label></div>
                                <div><input type="text" v-model="employeeModel.Employee.EmployeePosition" /></div>
                            </div>
                        </div>
                        <div class="general-right">
                            <div class="dob-gender">
                                <div class="dob">
                                    <div><label>Ngày sinh</label></div>
                                    <div><input type="date" v-model="employeeModel.Employee.DateOfBirth"/></div>
                                </div>
                                <div class="gender">
                                    <div><label>Giới tính</label></div>
                                    <div class="gender-male-female">
                                        <div class="gender-male">
                                            <div><input type="radio" name="nam" value=0 style="width: auto" v-model="employeeModel.Employee.Gender"></div>
                                            <div><label>Nam</label></div>
                                        </div>
                                        <div class="gender-female">
                                            <div><input type="radio" name="nu" value=1 style="width: auto" v-model="employeeModel.Employee.Gender"></div>
                                            <div><label>Nữ</label></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="identity-date">
                                <div class="indentity">
                                    <div><label for="">Số CMND</label></div>
                                    <div><input type="text" v-model="employeeModel.Employee.IdentityNumber"></div>
                                </div>
                                <div class="date">
                                    <div><label for="">Ngày cấp</label></div>
                                    <div><input type="date" v-model="employeeModel.Employee.IdentityDate"></div>
                                </div>
                            </div>
                            <div class="identity-address">
                                <div><label for="">Nơi cấp</label></div>
                                <div><input type="text" v-model="employeeModel.Employee.IdentityPlace"/></div>
                            </div>
                        </div>
                    </div>
                    <div class="contact-bankAccount">
                        <div class="title">
                            <div v-on:click="handleChangeTab('contactContent')" class="contact-title" :class="{inActiveClass:isActive1}">Liên hệ</div>
                            <div v-on:click="handleChangeTab('bankAccountContent')" class="bank-account-title" :class="{inActiveClass:isActive2}">Tài khoản ngân hàng</div>
                        </div>
                        <div v-if="tabSelected === 'contactContent'" class="contact-content">
                            <div class="contact-address">
                                <div><label for="">Địa chỉ</label></div>
                                <div><input type="text" v-model="employeeModel.Employee.EmployeeAdress"/></div>
                            </div>
                            <div class="phone-email">
                                <div class="phoneNumber">
                                    <div><label for="">ĐT di động</label></div>
                                    <div><input type="text" v-model="employeeModel.Employee.PhoneNumber"/></div>
                                </div>
                                <div class="teleNumber">
                                    <div><label for="">ĐT cố định</label></div>
                                    <div><input type="text" v-model="employeeModel.Employee.TeleNumber"/></div>
                                </div>
                                <div class="email">
                                    <div>
                                        <label for="">Email</label>
                                        <span class="require-charecter" v-if="checkRequiredField[3] === true">Định dạng email chưa đúng</span>
                                    </div>
                                    <div><input type="text" v-model="employeeModel.Employee.Email"/></div>
                                </div>
                            </div>
                        </div>
                        <div v-else class="bank-account-content">
                            <div class="bank-account-table">
                                <table>
                                    <thead>
                                        <th>SỐ TÀI KHOẢN</th>
                                        <th>TÊN NGÂN HÀNG</th>
                                        <th>CHI NHÁNH</th>
                                        <th>TỈNH/TP CỦA NGÂN HÀNG</th>
                                        <th></th>
                                    </thead>
                                    <tbody>
                                        <tr v-for="accountBank in employeeModel.EmployeeAccountBanks"
                                            :key="accountBank.EmployeeAccountId">
                                            <td><input type="text" v-model="accountBank.EmployeeAccountNumber"/></td>
                                            <td><input type="text" v-model="accountBank.BankName"/></td>
                                            <td><input type="text" v-model="accountBank.BranchName"/></td>
                                            <td><input type="text" v-model="accountBank.City"/></td>
                                            <td class="del-icon" @click="handleDeleteAccount(accountBank)"></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <div class="bank-account-btn">
                                <div class="btn-add-row" @click="handleAddRow">
                                    <button>Thêm dòng</button>
                                </div>
                                <div class="btn-delete-all-row" @click="handleDeleteAll">
                                    <button>Xóa hết dòng</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="footer-form">
                <div class="cancel" @click="handleCancle">
                    <BaseCancelButton
                    text="Hủy"/>
                </div>
                <div class="update" @click="handleSave">
                    <BaseButton
                    text="Cất"/>
                </div>
                <div class="save" @click="handleSave">
                    <BaseButton
                    text="Cất và thêm"/>
                </div>
            </div>
        </div>
        </div>
    </div>
</template>

<script>
import BaseButton from '../../../components/BaseComponent/BaseButton.vue'
import BaseCancelButton from '../../../components/BaseComponent/BaseCancelButton.vue'
import employeeService from '../../../service/employeeService/employeeService'
import employeeDepartmentService from '../../../service/employeeService/employeeDepartmentService'
import config from '../../../config.json'

export default {
    components: { BaseCancelButton, BaseButton },
    name: "EmployeeForm",
    props: {
        isHide: Boolean,
        employeeIdPro: String,
    },

    data() {
        return {
            tabSelected: 'contactContent',
            employeeModel: {
                EmployeeAccountBanks: [],
                Employee: {
                    EmployeeId: '',
                    EmployeeCode: '',
                },
            },
            employeeDepartmentList: [],
            accountBank: {
                EmployeeAccountNumber: '',
                BankName: '',
                BranchName: '',
                City: '',
                StateAccount: 0,
                EmployeeId: ''
            },
            checkRequiredField: [false, false, false, false],
            isActive1: true,
            isActive2: false,
        }
    },

    methods: {
        handleCloseForm(){
            this.$emit('handleClose', true);
            // this.$parent.
        },

        handleCancle(){
            this.$emit('handleCancel', true);
            this.employeeModel = {
                EmployeeAccountBanks: [],
                Employee: {
                    EmployeeId: '',
                },
            };
        },


        handleChangeTab(tab){
            this.tabSelected = tab;
            var tem = this.isActive1;
            this.isActive1 = this.isActive2;
            this.isActive2 = tem;
        },

        handleDeleteAccount(accountBank){
            var newList = [];
            for (let index = 0; index < this.employeeModel.EmployeeAccountBanks.length; index++) {
                if(this.employeeModel.EmployeeAccountBanks[index].EmployeeAccountNumber != accountBank.EmployeeAccountNumber){
                    newList.push(this.employeeModel.EmployeeAccountBanks[index]);
                }
            }
            this.employeeModel.EmployeeAccountBanks = newList;
        },

        handleAddRow(){
            var accountBank = {};
            this.employeeModel.EmployeeAccountBanks.push(accountBank);
        },

        handleDeleteAll(){
            this.employeeModel.EmployeeAccountBanks = [];
        },

        async handleSave(){
            this.checkRequiredField = employeeService.validate(this.employeeModel.Employee);
            var check = 0;
            for (let index = 0; index < this.checkRequiredField.length; index++) {
                if(this.checkRequiredField[index] == false){
                    check ++;
                }
            }
            if(check == 4){
                var res = await employeeService.saveEmployee(this.employeeModel);
                if(res.MisaCode === config.sucess){
                    this.employeeModel = {
                        EmployeeAccountBanks: [],
                        Employee: {
                            EmployeeId: '',
                        },
                    };
                    this.$emit("handleCloseAfterSave", res);
                }
                else{
                    this.$emit("handleCloseAfterSave", res);
                }
            }
        }
    },

    async created() {
        this.employeeDepartmentList = await employeeDepartmentService.getEmployeeDepartment();
        var employeeCode = await employeeService.getEmployeeCodeMax();
        this.employeeModel.Employee.EmployeeCode = employeeCode;
    },

    mounted(){
        
        this.$refs.employeeCode.focus();
    },
}
</script>

<style scoped>
.hideFormClass{
    display: none;
}

.inActiveClass{
    background-color: #EBF4FF;
    height: 32px;
    border: none;
}

.dialog-modal {
    opacity: .5;
    position: fixed;
    top: 0;
    left: 0;
    bottom: 0;
    right: 0;
    background-color: black;
    z-index: 2;
}

.dialog{
    height: 100%;
    width: 100%;
}

.container {
    width: 1000px;
    height: auto;
    border: solid 1px rgb(66, 53, 53);
    border-radius: 4px;
    position: fixed;
    left: 50%;
    top: 50%;
    background-color: white;
    z-index: 3;
    margin-top: -400px;
    margin-left: -350px;
}

.header-dialog {
    width: auto;
    height: 32px;
    display: flex;
    align-items: center;
    padding: 32px 32px 0px 32px;
}

    .header-dialog .header-dialog-text {
        font-size: 24px;
        font-weight: bolder;
    }
    .header-dialog .btn-close{
        background: url('../../../assets/img/Sprites.64af8f61.svg') no-repeat -147px -147px;
        width: 24px;
        height: 24px;
    }

    .header-dialog .btn-close:hover{
        background-color: red;
    }

.body-dialog{
    width: auto;
    height: auto;
    padding: 0 32px 32px 32px;
}

.general{
    width: auto;
    height: auto;
    display: flex;
    align-items: center;
}

.general-left{
    width: 50%;
    padding-right: 8px;
}

.general-right{
    width: 50%;
    padding-left: 8px;
}

.code-name{
    display: flex;
    align-items: center;
}

.dob-gender, .gender-male-female, .gender-male, .gender-female, .identity-date, .title, .phone-email, .bank-account-btn{
    display: flex;
    align-items: center;
}
.contact-title, .bank-account-title{
    padding: 4px;
}
.contact-title, .bank-account-title, .contact-content, .bank-account-content{
    border: 1px solid #bbbbbb;
}

.contact-content, .bank-account-content{
    height: 200px;
    overflow-y: auto;
}

.employeeName, .employeeCode, .dob, .gender, .indentity, .date{
    width: 50%;
    padding-right: 8px;
    padding-top: 8px;
}

.department, .position, .identity-address{
    padding-top: 8px;
}

.gender-male, .gender-female{
    width: 50%;
    padding-right: 8px;
}

.contact-address, .phone-email, .teleNumber, .email, .bank-account-table, .btn-add-row, .btn-delete-all-row{
    padding: 4px;
}

.contact-bankAccount{
    padding-top: 8px;
}

.contact-title, .bank-account-title{
    height: 24px;
    cursor: pointer;
}

/* .contact-title, .bank-account-title:hover{
    background-color: #EBF4FF;
} */


.footer-form{
    width: auto;
    height: 40px;
    display: flex;
    align-items: center;
    padding: 0 32px 32px 32px;
}

.del-icon{
    background: url('../../../assets/img/Sprites.64af8f61.svg') no-repeat -456px -300px;
	width: 20px;
	height: 15px;
    cursor: pointer;
}

.del-icon:hover{
    background-color: red;
}


.save{
    position: absolute;
    right: 16px;
}

.update{
    position: absolute;
    right: 132px;
}

label {
    font-weight: bold;
}

.require-charecter {
    color: red;
}
</style>