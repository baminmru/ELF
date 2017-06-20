<?php
	 class C_tplc_t extends CI_Controller {
    function __construct() {
         parent::__construct();
        $this->_loadModels();
    }
    function setRow() {
          log_message('debug', 'TPLC_T.setRow post : '.json_encode($this->input->post(NULL, FALSE)));
          log_message('debug', 'TPLC_T.getRows get : '.json_encode($this->input->get(NULL, FALSE)));
          $data = array(
                'tplc_tid' =>  $this->input->get_post('tplc_tid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'dcall' =>   $this->input->get_post('dcall', TRUE)
                ,'dcounter' =>   $this->input->get_post('dcounter', TRUE)
                ,'q1' =>   $this->input->get_post('q1', TRUE)
                ,'q2' =>   $this->input->get_post('q2', TRUE)
                ,'t1' =>   $this->input->get_post('t1', TRUE)
                ,'t2' =>   $this->input->get_post('t2', TRUE)
                ,'dt12' =>   $this->input->get_post('dt12', TRUE)
                ,'t3' =>   $this->input->get_post('t3', TRUE)
                ,'t4' =>   $this->input->get_post('t4', TRUE)
                ,'t5' =>   $this->input->get_post('t5', TRUE)
                ,'dt45' =>   $this->input->get_post('dt45', TRUE)
                ,'t6' =>   $this->input->get_post('t6', TRUE)
                ,'v1' =>   $this->input->get_post('v1', TRUE)
                ,'v2' =>   $this->input->get_post('v2', TRUE)
                ,'dv12' =>   $this->input->get_post('dv12', TRUE)
                ,'v3' =>   $this->input->get_post('v3', TRUE)
                ,'v4' =>   $this->input->get_post('v4', TRUE)
                ,'v5' =>   $this->input->get_post('v5', TRUE)
                ,'dv45' =>   $this->input->get_post('dv45', TRUE)
                ,'v6' =>   $this->input->get_post('v6', TRUE)
                ,'m1' =>   $this->input->get_post('m1', TRUE)
                ,'m2' =>   $this->input->get_post('m2', TRUE)
                ,'dm12' =>   $this->input->get_post('dm12', TRUE)
                ,'m3' =>   $this->input->get_post('m3', TRUE)
                ,'m4' =>   $this->input->get_post('m4', TRUE)
                ,'m5' =>   $this->input->get_post('m5', TRUE)
                ,'dm45' =>   $this->input->get_post('dm45', TRUE)
                ,'m6' =>   $this->input->get_post('m6', TRUE)
                ,'p1' =>   $this->input->get_post('p1', TRUE)
                ,'p2' =>   $this->input->get_post('p2', TRUE)
                ,'p3' =>   $this->input->get_post('p3', TRUE)
                ,'p4' =>   $this->input->get_post('p4', TRUE)
                ,'p5' =>   $this->input->get_post('p5', TRUE)
                ,'p6' =>   $this->input->get_post('p6', TRUE)
                ,'g1' =>   $this->input->get_post('g1', TRUE)
                ,'g2' =>   $this->input->get_post('g2', TRUE)
                ,'g3' =>   $this->input->get_post('g3', TRUE)
                ,'g4' =>   $this->input->get_post('g4', TRUE)
                ,'g5' =>   $this->input->get_post('g5', TRUE)
                ,'g6' =>   $this->input->get_post('g6', TRUE)
                ,'tcool' =>   $this->input->get_post('tcool', TRUE)
                ,'tce1' =>   $this->input->get_post('tce1', TRUE)
                ,'tce2' =>   $this->input->get_post('tce2', TRUE)
                ,'tsum1' =>   $this->input->get_post('tsum1', TRUE)
                ,'tsum2' =>   $this->input->get_post('tsum2', TRUE)
                ,'q1h' =>   $this->input->get_post('q1h', TRUE)
                ,'q2h' =>   $this->input->get_post('q2h', TRUE)
                ,'v1h' =>   $this->input->get_post('v1h', TRUE)
                ,'v2h' =>   $this->input->get_post('v2h', TRUE)
                ,'v4h' =>   $this->input->get_post('v4h', TRUE)
                ,'v5h' =>   $this->input->get_post('v5h', TRUE)
                ,'errtime' =>   $this->input->get_post('errtime', TRUE)
                ,'errtimeh' =>   $this->input->get_post('errtimeh', TRUE)
                ,'hc' =>   $this->input->get_post('hc', TRUE)
                ,'sp' =>   $this->input->get_post('sp', TRUE)
                ,'sp_tb1' =>   $this->input->get_post('sp_tb1', TRUE)
                ,'sp_tb2' =>   $this->input->get_post('sp_tb2', TRUE)
                ,'datetimecounter' =>   $this->input->get_post('datetimecounter', TRUE)
                ,'dg12' =>   $this->input->get_post('dg12', TRUE)
                ,'dg45' =>   $this->input->get_post('dg45', TRUE)
                ,'dp12' =>   $this->input->get_post('dp12', TRUE)
                ,'dp45' =>   $this->input->get_post('dp45', TRUE)
                ,'unitsr' =>   $this->input->get_post('unitsr', TRUE)
                ,'q3' =>   $this->input->get_post('q3', TRUE)
                ,'q4' =>   $this->input->get_post('q4', TRUE)
                ,'patm' =>   $this->input->get_post('patm', TRUE)
                ,'q5' =>   $this->input->get_post('q5', TRUE)
                ,'dq12' =>   $this->input->get_post('dq12', TRUE)
                ,'dq45' =>   $this->input->get_post('dq45', TRUE)
                ,'pxb' =>   $this->input->get_post('pxb', TRUE)
                ,'dq' =>   $this->input->get_post('dq', TRUE)
                ,'hc_1' =>   $this->input->get_post('hc_1', TRUE)
                ,'hc_2' =>   $this->input->get_post('hc_2', TRUE)
                ,'thot' =>   $this->input->get_post('thot', TRUE)
                ,'dans1' =>   $this->input->get_post('dans1', TRUE)
                ,'dans2' =>   $this->input->get_post('dans2', TRUE)
                ,'dans3' =>   $this->input->get_post('dans3', TRUE)
                ,'dans4' =>   $this->input->get_post('dans4', TRUE)
                ,'dans5' =>   $this->input->get_post('dans5', TRUE)
                ,'dans6' =>   $this->input->get_post('dans6', TRUE)
                ,'check_a' =>   $this->input->get_post('check_a', TRUE)
                ,'oktime' =>   $this->input->get_post('oktime', TRUE)
                ,'worktime' =>   $this->input->get_post('worktime', TRUE)
                ,'tair1' =>   $this->input->get_post('tair1', TRUE)
                ,'tair2' =>   $this->input->get_post('tair2', TRUE)
                ,'hc_code' =>   $this->input->get_post('hc_code', TRUE)
            );
            $tplc_t = $this->m_tplc_t->setRow($data);
            print json_encode($tplc_t);
    }
    function newRow() {
            log_message('debug', 'TPLC_T.newRow post : '.json_encode($this->input->post(NULL, FALSE)));
          $data = array(
                'tplc_tid' =>  $this->input->get_post('tplc_tid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'dcall' =>   $this->input->get_post('dcall', TRUE)
                ,'dcounter' =>   $this->input->get_post('dcounter', TRUE)
                ,'q1' =>   $this->input->get_post('q1', TRUE)
                ,'q2' =>   $this->input->get_post('q2', TRUE)
                ,'t1' =>   $this->input->get_post('t1', TRUE)
                ,'t2' =>   $this->input->get_post('t2', TRUE)
                ,'dt12' =>   $this->input->get_post('dt12', TRUE)
                ,'t3' =>   $this->input->get_post('t3', TRUE)
                ,'t4' =>   $this->input->get_post('t4', TRUE)
                ,'t5' =>   $this->input->get_post('t5', TRUE)
                ,'dt45' =>   $this->input->get_post('dt45', TRUE)
                ,'t6' =>   $this->input->get_post('t6', TRUE)
                ,'v1' =>   $this->input->get_post('v1', TRUE)
                ,'v2' =>   $this->input->get_post('v2', TRUE)
                ,'dv12' =>   $this->input->get_post('dv12', TRUE)
                ,'v3' =>   $this->input->get_post('v3', TRUE)
                ,'v4' =>   $this->input->get_post('v4', TRUE)
                ,'v5' =>   $this->input->get_post('v5', TRUE)
                ,'dv45' =>   $this->input->get_post('dv45', TRUE)
                ,'v6' =>   $this->input->get_post('v6', TRUE)
                ,'m1' =>   $this->input->get_post('m1', TRUE)
                ,'m2' =>   $this->input->get_post('m2', TRUE)
                ,'dm12' =>   $this->input->get_post('dm12', TRUE)
                ,'m3' =>   $this->input->get_post('m3', TRUE)
                ,'m4' =>   $this->input->get_post('m4', TRUE)
                ,'m5' =>   $this->input->get_post('m5', TRUE)
                ,'dm45' =>   $this->input->get_post('dm45', TRUE)
                ,'m6' =>   $this->input->get_post('m6', TRUE)
                ,'p1' =>   $this->input->get_post('p1', TRUE)
                ,'p2' =>   $this->input->get_post('p2', TRUE)
                ,'p3' =>   $this->input->get_post('p3', TRUE)
                ,'p4' =>   $this->input->get_post('p4', TRUE)
                ,'p5' =>   $this->input->get_post('p5', TRUE)
                ,'p6' =>   $this->input->get_post('p6', TRUE)
                ,'g1' =>   $this->input->get_post('g1', TRUE)
                ,'g2' =>   $this->input->get_post('g2', TRUE)
                ,'g3' =>   $this->input->get_post('g3', TRUE)
                ,'g4' =>   $this->input->get_post('g4', TRUE)
                ,'g5' =>   $this->input->get_post('g5', TRUE)
                ,'g6' =>   $this->input->get_post('g6', TRUE)
                ,'tcool' =>   $this->input->get_post('tcool', TRUE)
                ,'tce1' =>   $this->input->get_post('tce1', TRUE)
                ,'tce2' =>   $this->input->get_post('tce2', TRUE)
                ,'tsum1' =>   $this->input->get_post('tsum1', TRUE)
                ,'tsum2' =>   $this->input->get_post('tsum2', TRUE)
                ,'q1h' =>   $this->input->get_post('q1h', TRUE)
                ,'q2h' =>   $this->input->get_post('q2h', TRUE)
                ,'v1h' =>   $this->input->get_post('v1h', TRUE)
                ,'v2h' =>   $this->input->get_post('v2h', TRUE)
                ,'v4h' =>   $this->input->get_post('v4h', TRUE)
                ,'v5h' =>   $this->input->get_post('v5h', TRUE)
                ,'errtime' =>   $this->input->get_post('errtime', TRUE)
                ,'errtimeh' =>   $this->input->get_post('errtimeh', TRUE)
                ,'hc' =>   $this->input->get_post('hc', TRUE)
                ,'sp' =>   $this->input->get_post('sp', TRUE)
                ,'sp_tb1' =>   $this->input->get_post('sp_tb1', TRUE)
                ,'sp_tb2' =>   $this->input->get_post('sp_tb2', TRUE)
                ,'datetimecounter' =>   $this->input->get_post('datetimecounter', TRUE)
                ,'dg12' =>   $this->input->get_post('dg12', TRUE)
                ,'dg45' =>   $this->input->get_post('dg45', TRUE)
                ,'dp12' =>   $this->input->get_post('dp12', TRUE)
                ,'dp45' =>   $this->input->get_post('dp45', TRUE)
                ,'unitsr' =>   $this->input->get_post('unitsr', TRUE)
                ,'q3' =>   $this->input->get_post('q3', TRUE)
                ,'q4' =>   $this->input->get_post('q4', TRUE)
                ,'patm' =>   $this->input->get_post('patm', TRUE)
                ,'q5' =>   $this->input->get_post('q5', TRUE)
                ,'dq12' =>   $this->input->get_post('dq12', TRUE)
                ,'dq45' =>   $this->input->get_post('dq45', TRUE)
                ,'pxb' =>   $this->input->get_post('pxb', TRUE)
                ,'dq' =>   $this->input->get_post('dq', TRUE)
                ,'hc_1' =>   $this->input->get_post('hc_1', TRUE)
                ,'hc_2' =>   $this->input->get_post('hc_2', TRUE)
                ,'thot' =>   $this->input->get_post('thot', TRUE)
                ,'dans1' =>   $this->input->get_post('dans1', TRUE)
                ,'dans2' =>   $this->input->get_post('dans2', TRUE)
                ,'dans3' =>   $this->input->get_post('dans3', TRUE)
                ,'dans4' =>   $this->input->get_post('dans4', TRUE)
                ,'dans5' =>   $this->input->get_post('dans5', TRUE)
                ,'dans6' =>   $this->input->get_post('dans6', TRUE)
                ,'check_a' =>   $this->input->get_post('check_a', TRUE)
                ,'oktime' =>   $this->input->get_post('oktime', TRUE)
                ,'worktime' =>   $this->input->get_post('worktime', TRUE)
                ,'tair1' =>   $this->input->get_post('tair1', TRUE)
                ,'tair2' =>   $this->input->get_post('tair2', TRUE)
                ,'hc_code' =>   $this->input->get_post('hc_code', TRUE)
            );
                $instanceid =  $this->input->get_post('instanceid', TRUE);
            $tplc_t= $this->m_tplc_t->newRow($instanceid,$data);
            $return = $tplc_t;
            print json_encode($return);
    }
    function getRow() {
        log_message('debug', 'TPLC_T.getRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $empId  =  $this->input->get_post('id', TRUE);
        if (isset($empId)) {
            $tplc_t = $this->m_tplc_t->getRow($empId);
            $return = array(
                'success' => true,
                'data'    => $tplc_t
            );
            print json_encode($return);
        }
    }
    function getRows() {
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'dcall', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
            $instanceid=$this->input->get('instanceid', FALSE);
            if(isset($instanceid)){
                if($instanceid!=''){
                    $tplc_t= $this->m_tplc_t->getRowsByInstance($instanceid,$sort);
                }else{
                    $tplc_t= $this->m_tplc_t->getRows($sort);
                }
            }else{
              $tplc_t= $this->m_tplc_t->getRows($sort);
            }
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tplc_t
            );
        print json_encode($return);
    }
    function getRowsByInstance() {
        log_message('debug', 'TPLC_T.getRowsByInstance post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'dcall', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $InstId  =  $this->input->get_post('instanceid', TRUE);
        if (strlen($InstId) > 0) {
            $tplc_t= $this->m_tplc_t->getRowsByInstance($InstId,$sort);
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tplc_t
            );
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'Need instanceid to query.'
            );
        }
        print json_encode($return);
    }
    function getRowsByParent() {
        log_message('debug', 'TPLC_T.getRowsByParent post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'dcall', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $ParentId  =  $this->input->get_post('parentid', TRUE);
        if (strlen($ParentId) > 0) {
            $tplc_t= $this->m_tplc_t->getRowsByParent($ParentId,$sort);
            $return = array(
                'success' => TRUE,
                'data'    => $tplc_t
            );
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'Need parent parentid to query.'
            );
        }
        print json_encode($return);
    }
    function deleteRow() {
        log_message('debug', 'TPLC_T.deleteRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $tempId  =  $this->input->get_post('tplc_tid', TRUE);
        if (strlen($tempId) > 0) {
            $return = $this->m_tplc_t->deleteRow($tempId);
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'No  ID to delete'
            );
        }
        print json_encode($return);
    }
    private function _loadModels () {
        $this->load->model('M_tplc_t', 'm_tplc_t');
    }
}
?>