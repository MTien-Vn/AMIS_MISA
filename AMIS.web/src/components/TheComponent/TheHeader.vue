<template>
  <div class="header">
    <div class="left-header">
        <div class="department">
            <select>
                <option>Nhà hàng NMT</option>
                <option>Nhà hàng Việt Nam</option>
                <option>Nhà hàng Đông Á</option>
            </select>
        </div>
    </div>
    
    <div class="right-header">
        <div class="header-search">
            <input placeholder="Nhập từ khóa tìm kiếm"/>
            <div class="input-search-icon"></div>
        </div>
        <div class="header-option"></div>
        <div class="header-setting"></div>
        <div class="header-mess"></div>
        <div class="header-help"></div>
        <div class="header-notice"></div>
        <div class="account">
            <div class="account-icon"></div>
            <div class="account-name">
              <select>
                <option>Nguyen Manh Tien</option>
              </select>
            </div>
            <div class="account-option"></div>
        </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "TheHeader",
};
</script>

