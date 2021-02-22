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
                                        <span class="require-charecter"></span>
                                    </div>
                                    <div><input type="text" v-model="employee.EmployeeCode"/></div>
                                </div>
                                <div class="employeeName">
                                    <div>
                                        <label>Tên</label>
                                        <span class="require-charecter">*</span>
                                        <span class="require-charecter"></span>
                                    </div>
                                    <div><input type="text" v-model="employee.EmployeeName" /></div>
                                </div>
                            </div>
                            <div class="department">
                                <div>
                                    <label>Đơn vị</label>
                                    <span class="require-charecter">*</span>
                                    <span class="require-charecter"></span>
                                </div>
                                <div><select v-model="employee.EmployeeDepartmentId">
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
                                <div><input type="text" v-model="employee.EmployeePosition" /></div>
                            </div>
                        </div>
                        <div class="general-right">
                            <div class="dob-gender">
                                <div class="dob">
                                    <div><label>Ngày sinh</label></div>
                                    <div><input type="date" v-model="employee.DateOfBirth"/></div>
                                </div>
                                <div class="gender">
                                    <div><label>Giới tính</label></div>
                                    <div class="gender-male-female">
                                        <div class="gender-male">
                                            <div><input type="radio" name="nam" value=0 style="width: auto" v-model="employee.Gender"></div>
                                            <div><label>Nam</label></div>
                                        </div>
                                        <div class="gender-female">
                                            <div><input type="radio" name="nu" value=1 style="width: auto" v-model="employee.Gender"></div>
                                            <div><label>Nữ</label></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="identity-date">
                                <div class="indentity">
                                    <div><label for="">Số CMND</label></div>
                                    <div><input type="text" v-model="employee.IdentityNumber"></div>
                                </div>
                                <div class="date">
                                    <div><label for="">Ngày cấp</label></div>
                                    <div><input type="date" v-model="employee.IdentityDate"></div>
                                </div>
                            </div>
                            <div class="identity-address">
                                <div><label for="">Nơi cấp</label></div>
                                <div><input type="text" v-model="employee.IdentityPlace"/></div>
                            </div>
                        </div>
                    </div>
                    <div class="contact-bankAccount">
                        <div class="title">
                            <div v-on:click="handleChangeTab('contactContent')" class="contact-title">Liên hệ</div>
                            <div v-on:click="handleChangeTab('bankAccountContent')" class="bank-account-title">Tài khoản ngân hàng</div>
                        </div>
                        <div v-if="tabSelected === 'contactContent'" class="contact-content">
                            <div class="contact-address">
                                <div><label for="">Địa chỉ</label></div>
                                <div><input type="text" v-model="employee.EmployeeAdress"/></div>
                            </div>
                            <div class="phone-email">
                                <div class="phoneNumber">
                                    <div><label for="">ĐT di động</label></div>
                                    <div><input type="text" v-model="employee.PhoneNumber"/></div>
                                </div>
                                <div class="teleNumber">
                                    <div><label for="">ĐT cố định</label></div>
                                    <div><input type="text" v-model="employee.TeleNumber"/></div>
                                </div>
                                <div class="email">
                                    <div><label for="">Email</label></div>
                                    <div><input type="text" v-model="employee.Email"/></div>
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
                                        <tr v-for="accountBank in accountBankList"
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
                <div class="cancel" @click="handleCloseForm">
                    <BaseCancelButton
                    text="Hủy"/>
                </div>
                <div class="update">
                    <BaseButton
                    text="Cất"/>
                </div>
                <div class="save">
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
export default {
    components: { BaseCancelButton, BaseButton },
    name: "EmployeeForm",
    props: {
        isHide: Boolean,
    },

    data() {
        return {
            tabSelected: 'contactContent',
            employeeDepartmentList: [],
            accountBankList: [],
            accountBank: {
                EmployeeAccountNumber: '',
                BankName: '',
                BranchName: '',
                City: '',
                StateAccount: 0,
                EmployeeId: ''
            },
            employee: {},
        }
    },

    methods: {
        handleCloseForm(){
            this.$emit('handleClose', true);
        },

        handleChangeTab(tab){
            this.tabSelected = tab;
        },

        handleDeleteAccount(accountBank){
            var newList = [];
            for (let index = 0; index < this.accountBankList.length; index++) {
                if(this.accountBankList[index].EmployeeAccountNumber != accountBank.EmployeeAccountNumber){
                    newList.push(this.accountBankList[index]);
                }
            }
            this.accountBankList = newList;
        },

        handleAddRow(){
            var accountBank = {};
            this.accountBankList.push(accountBank);
        },

        handleDeleteAll(){
            this.accountBankList = [];
        }
    },
}
</script>

<style scoped>
.hideFormClass{
    display: none;
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
    padding: 32px;
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

.contact-title, .bank-account-title, .contact-content, .bank-account-content{
    border: 1px solid #bbbbbb;
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

.contact-title, .bank-account-title:hover{
    background-color: #EBF4FF;
}

.contact-title, .bank-account-title:active{
    height: 32px;
    border: none;
    background-color: #EBF4FF;
}

.footer-form{
    width: auto;
    height: 40px;
    display: flex;
    align-items: center;
    border-top: 1px solid #bbbbbb;
    padding: 32px;
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

.cancel{
    
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