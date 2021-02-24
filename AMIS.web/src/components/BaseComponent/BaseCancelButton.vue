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
    background-color: #ffffff;
    border-radius: 4px;
    height: 40px;
    font-size: 13px;
    color: black;
    font-family: notosans-Regular;
    padding-left: 16px;
    padding-right: 16px;
    outline: none;
    border: 1px solid #bbbbbb;
    cursor: pointer;
    min-width: 100px;
    justify-content: center;
}
    .m-btn2:hover {
        background-color: #FF6900;
    }
</style>