<template>
  <div class="navbar">
    <div class="logo-site">
      <router-link class="logo-box" to="/">
        <div class="toggle-icon"></div>
        <div class="amis-logo"></div>
      </router-link>
    </div>
    <div class="navbar-content">
      <router-link class="navbar-item" to="/">
        <div class="navbar-item-icon nav-item-dashboard"></div>
        <div class="navbar-item-content">Tổng quan</div>
      </router-link>
      <router-link class="navbar-item" to="/">
        <div class="navbar-item-icon nav-item-currency"></div>
        <div class="navbar-item-content">Tiền Mặt</div>
      </router-link>
      <router-link class="navbar-item" to="/">
        <div class="navbar-item-icon nav-item-deposits"></div>
        <div class="navbar-item-content">Tiền Gửi</div>
      </router-link>
      <router-link class="navbar-item" to="/dictionary/customer">
        <div class="navbar-item-icon nav-item-shopping"></div>
        <div class="navbar-item-content">Mua Hàng</div>
      </router-link>
      <router-link class="navbar-item" to="/dictionary/employee">
        <div class="navbar-item-icon nav-item-sell"></div>
        <div class="navbar-item-content">Bán Hàng</div>
      </router-link>
      <router-link class="navbar-item" to="/">
        <div class="navbar-item-icon nav-item-order"></div>
        <div class="navbar-item-content">Quản lý đơn</div>
      </router-link>
      <router-link class="navbar-item" to="/dictionary/employee">
        <div class="navbar-item-icon nav-item-repository"></div>
        <div class="navbar-item-content">Kho</div>
      </router-link>
      <router-link class="navbar-item" to="/dictionary/employee">
        <div class="navbar-item-icon nav-item-tool"></div>
        <div class="navbar-item-content">Công cụ công dung</div>
      </router-link>
      <router-link class="navbar-item" to="/dictionary/employee">
        <div class="navbar-item-icon nav-item-assets"></div>
        <div class="navbar-item-content">Tài sản cố định</div>
      </router-link>
      <router-link class="navbar-item" to="/dictionary/employee">
        <div class="navbar-item-icon nav-item-tax"></div>
        <div class="navbar-item-content">Thuế</div>
      </router-link>
      <router-link class="navbar-item" to="/dictionary/employee">
        <div class="navbar-item-icon nav-item-cost"></div>
        <div class="navbar-item-content">Giá thành</div>
      </router-link>
      <router-link class="navbar-item" to="/dictionary/employee">
        <div class="navbar-item-icon nav-item-common"></div>
        <div class="navbar-item-content">Tổng hợp</div>
      </router-link>
      <router-link class="navbar-item" to="/dictionary/employee">
        <div class="navbar-item-icon nav-item-budget"></div>
        <div class="navbar-item-content">Ngân sách</div>
      </router-link>
      <router-link class="navbar-item" to="/dictionary/employee">
        <div class="navbar-item-icon nav-item-report"></div>
        <div class="navbar-item-content">Báo cáo</div>
      </router-link>
      <router-link class="navbar-item" to="/dictionary/employee">
        <div class="navbar-item-icon nav-item-analysis"></div>
        <div class="navbar-item-content">Phân tích tài chính</div>
      </router-link>
    </div>
  </div>
</template>

<script>
export default {
  name: "TheNavar",
  data() {
    return {
      employee: "/dictionary/employee",
    };
  },
};
</script>
