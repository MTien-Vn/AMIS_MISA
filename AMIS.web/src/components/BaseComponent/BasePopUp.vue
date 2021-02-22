<template>
    <div>
        <div :class="{isHide:isActive}">
            <div class="pop-up-modal"></div>
            <div class="pup-up-container">
                <div class="pop-up-header">
                    <div class="pop-up-header-text">{{textHeader}}</div>
                </div>
                <div class="pop-up-content">
                    <div>{{textContent}}</div>
                </div>
                <div class="pop-up-footer">
                    <div v-on:click="cancel">
                        <BaseCancelButton  
                            :text="textCancel" 
                            class="re-background-color"/>
                    </div>
                    
                    <div v-on:click="confirm">
                        <BaseCancelButton 
                            :text="textConfirm" />
                    </div>
                    
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import BaseCancelButton from '../BaseComponent/BaseCancelButton';
export default {
    name: 'BasePopUp',
    components: {
        BaseCancelButton
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
            this.$emit('confirmPopUp', true);
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
    width: 300px;
    height: auto;
    border: solid 1px rgb(red, green, blue);
    border-radius: 4px;
    position: fixed;
    left: 50%;
    right: 50%;
    background-color: #E9EBEE;
    z-index: 3;
    margin-top: auto;
    margin-left: -150px;
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
    padding-left: 24px;
    padding-right: 24px;
}

.pop-up-footer{
    height: 60px;
    display: flex;
    align-items: flex-end;
    padding: 16px 10px 10px;
}

.re-background-color{
    background-color: #BBBBBB;
}

.re-background-color:hover{
    background-color: #DADCE0;
}
</style>