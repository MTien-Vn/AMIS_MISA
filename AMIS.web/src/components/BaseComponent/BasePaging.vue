<template>
        <div class="paging-bar">
            <div class="paging-total-recored">Tổng số: {{totalObject}} bản ghi</div>
            <div class="paging-infor">
                <div class="paging-option-record">
                    <select v-model="newLimmit" @change="changeLimit">
                        <option value=5 >5 {{objectName}} / trang</option>
                        <option value=10 >10 {{objectName}} / trang</option>
                        <option value=15 >15 {{objectName}} / trang</option>
                    </select>
                </div>
                <div class="paging-option">
                    <div class="btn-prev-page" id="prev-page" v-on:click="changePage(pageNumber - 1)">Trước</div>
                    <div class="page-list">
                        <div class="page-number" id="page-number-1" :class="{isActive: isActive1}"  v-on:click="changePage(1)">1</div>
                        <div class="page-number" id="page-number-2" :class="{isActive: isActive2}"  v-on:click="changePage(2)" >2</div>
                        <div class="page-number" id="page-number-3" :class="{isActive: isActive3}"  v-on:click="changePage(3)" >3</div>
                        <div class="page-number" id="page-number-4" :class="{isActive: isActive4}"  v-on:click="changePage(4)" >4</div>
                    </div>
                    <div class="btn-next-page" id="next-page" v-on:click="changePage(pageNumber + 1)">Sau</div>
                </div>
            </div>
            
        </div>
</template>

<script>
export default {
    name: 'BasePaging',
    props: {
        objectName: String,
        totalObject: Number,
        totalPage: Number,
        limmitPage: Number,
        currentPage: Number
    },
    data() {
        return {
            total : 0,
            total_page : 0,
            limmit : 0,
            pageNumber : 1,
            newLimmit : 10,
            isActive1: true,
            isActive2: false,
            isActive3: false,
            isActive4: false,
            isActiveLast: false
        }
    },
    methods: {
        changePage(number){
            if(number > this.total_page){
                this.isActiveLast = true;
                this.pageNumber = this.total_page;
            }else if(number < 1){
                this.pageNumber = 1;
            }else{
                this.pageNumber = number;
                switch(number){
                    case 1:{
                        this.isActive1 =  true;
                        this.isActive2 =  false;
                        this.isActive3 =  false;
                        this.isActive4 =  false;
                        break;
                    }
                    case 2:{
                        this.isActive1 =  false;
                        this.isActive2 =  true;
                        this.isActive3 =  false;
                        this.isActive4 =  false;
                        break;
                    }
                    case 3:{
                        this.isActive1 =  false;
                        this.isActive2 =  false;
                        this.isActive3 =  true;
                        this.isActive4 =  false;
                        break;
                    }
                    case 4:{
                        this.isActive1 =  false;
                        this.isActive2 =  false;
                        this.isActive3 =  false;
                        this.isActive4 =  true;
                        break;
                    }
                }
            }
            this.$emit('handleChangPage', this.pageNumber);
        },
        changeLimit(){
            this.$emit("handleChangeLimit", this.newLimmit);
        }
    },

    computed: {
        fromIndex(){
           return (this.limmit)*(this.pageNumber-1)+1
        },
        toIndex(){
            if(this.total < (this.limmit)*(this.pageNumber)){
                return this.total
            }else{
                return (this.limmit)*(this.pageNumber)      
            }
        }
    },

    updated(){
        this.total = this.totalObject;
        this.total_page = this.totalPage;
        this.limmit = this.limmitPage;
        this.pageNumber = this.currentPage;
    }
}
</script>

<style scoped>
.isActive{
    background-color: #0075FF;
}

.paging-bar {
    width: calc(100% - 32px);
    border-top: 2px solid #bbbbbb;
    position: absolute;
    display: flex;
    align-items: center;
    padding: 0 16px;
    bottom: 0;
}

.paging-bar .paging-total-recored {
    position: relative;
    width: 20%;
    height: 40px;
    padding: 16px 0 16px 0;
    display: flex;
    align-items: center;
}

.paging-infor{
    position: absolute;
    right: 16px;
    display: flex;
    align-items: center;
    width: auto;
    height: auto;
}

.paging-bar .paging-option-record {
    width: auto;
    height: 40px;
    padding: 16px;
    display: flex;
    align-items: center;
}

.paging-bar .paging-option {
    position: relative;
    width: 20%;
    height: 40px;
    display: flex;
    align-items: center;
    justify-content: center;
    padding-left: 48px;
}

.paging-option .page-list {
    display: flex;
    align-items: center;
}

.page-number {
    width: 20px;
    height: 20px;
    border: 1px solid #808080;
    cursor: pointer;
    text-align: center;
    margin-right: 8px;
}

    .page-number:hover {
        background-color: #0075ff
    }

.btn-prev-page, .btn-next-page{
    cursor: pointer;
}

.btn-prev-page:hover{
    background-color: #0075ff
}

.btn-next-page:hover{
    background-color: #0075ff
}

.btn-prev-page{
    padding-right: 8px;
}
</style>
