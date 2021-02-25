<template>
  <div class="content">
    <div class="content-header">
      <div class="content-header-left">
        <div class="content-header-title">Nhân viên</div>
        <div class="content-header-back">Tất cả danh mục</div>
      </div>
      <div class="content-header-right">
        <div class="content-header-addBtn">
          <div class="btn-add" @click="handleShowForm">
            <BaseButton text="Thêm" />
          </div>
        </div>
        <EmployeeForm :isHide="isHideForm" 
                      @handleClose="handleCloseForm" 
                      @handleCloseAfterSave="handleCloseAfterSave"
                      @handleCancel="handleCancel"
                      ref="EmployeeForm"              
        />

        <BasePopUpNotice :isActive="isHidePopUpNotice" 
                         textConfirm="Xác nhận"
                         :textContent="contentPopUp"
                        @confirmPopUpNotice="handleClosePopUpNotice"/>

        <BasePopUpWarn  :isActive="isHidePopUpWarn"
                         textCancel="Không"
                         textConfirm="Có"
                         :textContent="contentPopUp"
                         @closePopUp="handleClosePopUpWarn"
                         @confirmPopUp="handleConfirmPopUpWarn"/>
      </div>
    </div>
    <div class="content-body">
      <div class="content-body-search">
        <div class="header-search">
          <input
            placeholder="Tìm kiếm theo mã, tên nhân viên"
            title="Tìm kiếm theo mã, tên nhân viên"
            v-model="keyWord"
            v-on:keyup.enter="getKeyWord(keyWord)"
          />
          <div class="input-search-icon"></div>
        </div>
      </div>
      <div class="content-body-table">
        <table>
          <thead>
            <th style="width: 100px">MÃ NHÂN VIÊN</th>
            <th style="width: 200px">TÊN NHÂN VIÊN</th>
            <th style="width: 100px">CHỨC DANH</th>
            <th style="width: 200px">TÊN ĐƠN VỊ</th>
            <th style="width: 100px">SỐ TÀI KHOẢN</th>
            <th style="width: 200px">TÊN NGÂN HÀNG</th>
            <th style="width: 100px">CHI NHÁNH</th>
            <th style="width: 100px">TRẠNG THÁI</th>
            <th style="width: 100px">CHỨC NĂNG</th>
          </thead>
          <tbody>
            <tr v-for="(employee, index) in employeeList" :key="index">
              <td>{{ employee.EmployeeCode }}</td>
              <td>{{ employee.EmployeeName }}</td>
              <td>{{ employee.EmployeePosition }}</td>
              <td>{{ employee.EmployeeDepartmentName }}</td>
              <td>{{ employee.EmployeeAccountNumber }}</td>
              <td>{{ employee.BankName }}</td>
              <td>{{ employee.BranchName }}</td>
              <td>{{ handleStateBank(employee.StateAccount) }}</td>
              <td>
                <div class="function-container">
                  <div class="function-edit" @click="handleEdit(employee.EmployeeId)">Sửa</div>
                  <div class="function-other" @click="handleOther(index)">
                    <div class="function-box">
                      <div class="function-icon"></div>
                    </div>
                    <div class="edit-contnet" v-if="isHideEditContent === index">
                      <div class="edit-copy" @click="handleDup">Nhân bản</div>
                      <div class="edit-delete" @click="handleDeleteEmloyee(employee.EmployeeCode)">Xóa</div>
                      <div class="edit-stop-using" @click="handleStateAccountBank(employee)">Ngừng sử dụng</div>
                    </div>
                </div>
                </div>
                
              </td>
            </tr>
          </tbody>
        </table>
      </div>
      <div class="content-body-footer">
        <BasePaging
          objectName="Nhân viên"
          :currentPage="page"
          :limmitPage="limmit"
          :totalObject="total"
          :totalPage="totalPage"
          @handleChangPage="handleChangPage"
          @handleChangeLimit="handleChangeLimit"
        />
      </div>
    </div>
  </div>
</template>

<script>
import BaseButton from "../../../components/BaseComponent/BaseButton.vue";
import BasePaging from "../../../components/BaseComponent/BasePaging.vue";
import EmployeeBanKService from '../../../service/employeeService/employeeAccountBankService';
import EmployeeService from "../../../service/employeeService/employeeService";
import BaseService from "../../../service/baseService";
import config from "../../../config.json";
import EmployeeForm from "./EmployeeForm.vue";
import BasePopUpNotice from '../../../components/BaseComponent/BasePopUpNotice.vue';
import BasePopUpWarn from '../../../components/BaseComponent/BasePopUpWarn.vue';
export default {
  components: {
    BaseButton,
    BasePaging,
    EmployeeForm,
    BasePopUpNotice,
    BasePopUpWarn,
  },

  name: "EmployeeList",

  data() {
    return {
      isHideForm: true,
      isHidePopUpNotice: true,
      isHidePopUpWarn: true,
      employeeList: [],
      page: 1,
      limmit: 15,
      total: 0,
      totalPage: 0,
      misaCode: config.default,
      keyWord: "",
      isHideEditContent: -1,
      contentPopUp: '',
      employeeCode: '',
    };
  },

  methods: {
    handleStateBank(state) {
      return BaseService.handleState(state);
    },

    handleShowForm() {
      this.isHideForm = false;
    },

    handleCloseForm(res) {
      this.isHideForm = res;
    },

    handleCancel(res){
      this.isHideForm = res;
    },

    handleDate(data){
        return BaseService.handleDate2(data);
    },
    
    handleOther(index) {
      if (this.isHideEditContent == -1) {
        this.isHideEditContent = index;
      } else {
        this.isHideEditContent = -1;
      }
    },

    handleClosePopUpNotice(){
      this.isHidePopUpNotice = true;
        this.getEmployee();
    },

    handleCloseAfterSave(res) {
      this.isHideForm = true;
      if(res.MisaCode === config.sucess){
        this.isHidePopUpNotice = false;
        this.contentPopUp = res.Messenger.toString();
        this.getEmployee();
      }
      else{
        this.isHidePopUpNotice = false;
        this.contentPopUp = res.Messenger.toString();
      }
    },

    async handleEdit(employeeId){
      this.isHideForm = false;
      var employee = await EmployeeService.getEmployeeById(employeeId);
      var accountBankList = await EmployeeBanKService.getEmployeeBankByEmployeeId(employeeId);
      if(employee.DateOfBirth !== null && employee.DateOfBirth !== ''){
        employee.DateOfBirth = this.handleDate(employee.DateOfBirth);
      }
      if(employee.IdentityDate !== null && employee.IdentityDate !== ''){
        employee.IdentityDate = this.handleDate(employee.IdentityDate);
      }
      this.$refs.EmployeeForm.employeeModel.Employee = employee;
      this.$refs.EmployeeForm.employeeModel.EmployeeAccountBanks = accountBankList;
    },

    handleDup(){
      alert("Đang phát triển");
    },

    handleDeleteEmloyee(employeeCode){
      this.isHidePopUpWarn = false;
      this.contentPopUp = "Bạn có muốn xóa "+employeeCode;
      this.employeeCode = employeeCode;
    },

    handleStateAccountBank(){
      alert("Đang phát triển");
    },

    async getEmployee() {
      this.employeeList = await EmployeeService.getEmployee(
        this.page,
        this.limmit
      );
      this.total = await EmployeeService.numberEmployee();
      this.totalPage = Math.ceil(this.total / this.limmit);
      
      console.log(this.employeeList);
    },

    async handleSearch(keyWord) {
      if (keyWord == "") {
        alert("key word không được trống");
      } else {
        this.employeeList = await EmployeeService.getEmployeeByKey(
          keyWord,
          this.page,
          this.limmit
        );
        this.total = await EmployeeService.numberEmployeeByKey(keyWord);
        this.total_page = Math.ceil(this.total / this.limmit);
      }
    },

    getKeyWord(key) {
      this.keyWord = key;
      this.page = 1;
      this.handleSearch(this.keyWord);
    },

    handleChangPage(page) {
      this.page = page;
      if (this.keyWord != "") {
        if (this.page <= this.totalPage) this.handleSearch(this.keyWord);
      } else {
        if (this.page <= this.totalPage) this.getEmployee();
      }
    },

    handleChangeLimit(limit) {
      this.limmit = Number(limit);
      if (this.keyWord != "") {
        if (this.page <= this.totalPage) this.handleSearch(this.keyWord);
      } else {
        if (this.page <= this.totalPage) this.getEmployee();
      }
    },

    handleClosePopUpWarn(){
      this.isHidePopUpWarn = true;
      this.employeeCode = '';
      this.getEmployee();
    },

    async handleConfirmPopUpWarn(){
      await EmployeeService.deleteEmployeeByCode(this.employeeCode);
      this.employeeCode = '';
      this.isHidePopUpWarn = true;
      await this.getEmployee();
    },
  },

  async created() {
    this.employeeList = await EmployeeService.getEmployee(
      this.page,
      this.limmit
    );
    this.total = await EmployeeService.numberEmployee();
    this.totalPage = Math.ceil(this.total / this.limmit);
  },

  // updated(){
      
  //     this.getEmployee();
  // }
};
</script>

<style scoped>
.function-container{
  display: flex;
  align-items: center;
  cursor: pointer;
  position: relative;
  padding-left: 16px;
}

.function-edit {
  color: #0075ff;
  margin: 4px;
}

.function-box {
  width: 16px;
  height: 12px;
  border: 1px solid #0075ff;
}

.function-icon {
  background: url("../../../assets/img/Sprites.64af8f61.svg") no-repeat -900px -365px;
  width: 8px;
  height: 5px;
  margin: 4px;
}

.edit-contnet {
  width: 100px;
  height: auto;
  position: absolute;
  left: 0px;
  border: 1px solid #bbbbbb;
  background-color: white;
  z-index: 3;
}

.edit-copy,
.edit-delete,
.edit-stop-using {
  height: auto;
  width: auto;
  padding: 8px;
}

.edit-copy:hover {
  background-color: #bbbbbb;
}
.edit-delete:hover {
  background-color: #bbbbbb;
}
.edit-stop-using:hover {
  background-color: #bbbbbb;
}

.edit-copy:active {
  color: #019160;
}
.edit-delete {
  color: #019160;
}
.edit-stop-using:active {
  color: #019160;
}
</style>