<template>
    <div>
        <div :class="{isHide:isActive}">
            <div class="pop-up-modal"></div>
            <div class="pup-up-container">
                <div class="pop-up-content">
                    <div class="icon"></div>
                    <div class="content-text">{{textContent}}</div>
                </div>
                <div style="padding: 0 16px 0 16px"><hr></div>
                <div class="pop-up-footer">
                    <div v-on:click="cancel" class="cancel-btn">
                        <BaseCancelButton  
                            :text="textCancel" 
                            class="re-background-color"/>
                    </div>
                    
                    <div v-on:click="confirm" class="confirm-btn">
                        <BaseButton 
                            :text="textConfirm" />
                    </div>
                    
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import BaseCancelButton from '../BaseComponent/BaseCancelButton';
import BaseButton from './BaseButton.vue';
export default {
    name: 'BasePopUpWarn',
    components: {
        BaseCancelButton,
        BaseButton
    },
    props: {
        textHeader: String,
        textContent: String,
        textCancel: String,
        textConfirm: String,
        isActive: Boolean
    },
    methods: {
        cancel(){
            this.$emit("closePopUp", true);
        },
        confirm(){
            this.$emit("confirmPopUp", true);
        }
    }

}
</script>

<style scoped>
.isHide{
    display: none;
}

.pop-up-modal{
    opacity: .5;
    position: fixed;
    top: 0;
    left: 0;
    bottom: 0;
    right: 0;
    background-color: black;
    z-index: 2;
}
.pup-up-container{
    width: 400px;
    height: auto;
    border: solid 1px rgb(red, green, blue);
    border-radius: 4px;
    position: fixed;
    left: 50%;
    right: 50%;
    background-color: #ffffff;
    z-index: 3;
    margin-top: auto;
    margin-left: -200px;
}
.pop-up-header{
    width: 100%;
    height: 60px;
    display: flex;
    align-items: center;
}

.pop-up-header-text{
    font-size: 15px;
    font-weight: bolder;
    padding: 24px 24px 24px;
}

.pop-up-content{
    font-size: 13px;
    padding: 16px;
    display: inline-block;
}

.icon{
    background: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -598px -463px;
	width: 36px;
	height: 37px;
}

.content-text{
    text-align: center;
}

.pop-up-footer{
    height: 60px;
    display: flex;
    align-items: center;
    padding: 16px;
}

.confirm-btn{
    position: absolute;
    right: 8px;
}


.re-background-color{
    background-color: #ffffff;
}

.re-background-color:hover{
    background-color: #DADCE0;
}
</style>