<template>
    <button class="m-btn2">
        {{text}}
    </button>
</template>

<script>
export default {
    name: 'BaseCancelButton',
    props: {
        text: String
    }
}
</script>

<style scoped>
.m-btn2{
    display: flex;
    align-items: center;
    background-color: #F65454;
    border-radius: 4px;
    height: 40px;
    font-size: 13px;
    color: #ffffff;
    font-family: GoogleSans-Regular;
    padding-left: 16px;
    padding-right: 16px;
    outline: none;
    border: none;
    cursor: pointer;
    min-width: 100px;
    justify-content: center;
}
    .m-btn2:hover {
        background-color: #FF6900;
    }
</style>