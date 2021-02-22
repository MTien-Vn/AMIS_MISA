<template>
    <button class="m-btn2">
        <div v-bind:class="{icon_add: isActive}"></div>
        <div class="text-add">{{text}}</div>
    </button>
</template>

<script>
export default {
    name: 'BaseButton',
    props: {
        text: String,
        urlImg: String
    },
    data() {
        return {
            isActive: true
        }
    },
    computed:{
        background(){
            return 'url(' + this.urlImg + ')';
        }
    },
    methods: {
        displayIcon(){
            if(this.urlImg != null && this.urlImg != ''){
                this.isActive = true; 
            }
        }
    },
}
</script>

<style scoped>
.m-btn2{
    display: flex;
    align-items: center;
    background-color: #019160;
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
    margin: 8px;
}
    .m-btn2:hover {
        background-color: #2FBE8E;
    }

</style>