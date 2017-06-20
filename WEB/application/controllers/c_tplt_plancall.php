<?php
	 class C_tplt_plancall extends CI_Controller {
    function __construct() {
         parent::__construct();
        $this->_loadModels();
    }
    function setRow() {
          log_message('debug', 'TPLT_PLANCALL.setRow post : '.json_encode($this->input->post(NULL, FALSE)));
          log_message('debug', 'TPLT_PLANCALL.getRows get : '.json_encode($this->input->get(NULL, FALSE)));
          $data = array(
                'tplt_plancallid' =>  $this->input->get_post('tplt_plancallid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'cstatus' =>   $this->input->get_post('cstatus', TRUE)
                ,'nmaxcall' =>   $this->input->get_post('nmaxcall', TRUE)
                ,'minrepeat' =>   $this->input->get_post('minrepeat', TRUE)
                ,'dlock' =>   $this->input->get_post('dlock', TRUE)
                ,'dlastcall' =>   $this->input->get_post('dlastcall', TRUE)
                ,'ccurr' =>   $this->input->get_post('ccurr', TRUE)
                ,'icallcurr' =>   $this->input->get_post('icallcurr', TRUE)
                ,'dnextcurr' =>   $this->input->get_post('dnextcurr', TRUE)
                ,'chour' =>   $this->input->get_post('chour', TRUE)
                ,'icall' =>   $this->input->get_post('icall', TRUE)
                ,'numhour' =>   $this->input->get_post('numhour', TRUE)
                ,'dnexthour' =>   $this->input->get_post('dnexthour', TRUE)
                ,'dlasthour' =>   $this->input->get_post('dlasthour', TRUE)
                ,'c24' =>   $this->input->get_post('c24', TRUE)
                ,'icall24' =>   $this->input->get_post('icall24', TRUE)
                ,'num24' =>   $this->input->get_post('num24', TRUE)
                ,'dnext24' =>   $this->input->get_post('dnext24', TRUE)
                ,'dlastday' =>   $this->input->get_post('dlastday', TRUE)
                ,'csum' =>   $this->input->get_post('csum', TRUE)
                ,'icallsum' =>   $this->input->get_post('icallsum', TRUE)
                ,'dnextsum' =>   $this->input->get_post('dnextsum', TRUE)
                ,'cel' =>   $this->input->get_post('cel', TRUE)
                ,'iel' =>   $this->input->get_post('iel', TRUE)
                ,'dnextel' =>   $this->input->get_post('dnextel', TRUE)
            );
            $tplt_plancall = $this->m_tplt_plancall->setRow($data);
            print json_encode($tplt_plancall);
    }
    function newRow() {
            log_message('debug', 'TPLT_PLANCALL.newRow post : '.json_encode($this->input->post(NULL, FALSE)));
          $data = array(
                'tplt_plancallid' =>  $this->input->get_post('tplt_plancallid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'cstatus' =>   $this->input->get_post('cstatus', TRUE)
                ,'nmaxcall' =>   $this->input->get_post('nmaxcall', TRUE)
                ,'minrepeat' =>   $this->input->get_post('minrepeat', TRUE)
                ,'dlock' =>   $this->input->get_post('dlock', TRUE)
                ,'dlastcall' =>   $this->input->get_post('dlastcall', TRUE)
                ,'ccurr' =>   $this->input->get_post('ccurr', TRUE)
                ,'icallcurr' =>   $this->input->get_post('icallcurr', TRUE)
                ,'dnextcurr' =>   $this->input->get_post('dnextcurr', TRUE)
                ,'chour' =>   $this->input->get_post('chour', TRUE)
                ,'icall' =>   $this->input->get_post('icall', TRUE)
                ,'numhour' =>   $this->input->get_post('numhour', TRUE)
                ,'dnexthour' =>   $this->input->get_post('dnexthour', TRUE)
                ,'dlasthour' =>   $this->input->get_post('dlasthour', TRUE)
                ,'c24' =>   $this->input->get_post('c24', TRUE)
                ,'icall24' =>   $this->input->get_post('icall24', TRUE)
                ,'num24' =>   $this->input->get_post('num24', TRUE)
                ,'dnext24' =>   $this->input->get_post('dnext24', TRUE)
                ,'dlastday' =>   $this->input->get_post('dlastday', TRUE)
                ,'csum' =>   $this->input->get_post('csum', TRUE)
                ,'icallsum' =>   $this->input->get_post('icallsum', TRUE)
                ,'dnextsum' =>   $this->input->get_post('dnextsum', TRUE)
                ,'cel' =>   $this->input->get_post('cel', TRUE)
                ,'iel' =>   $this->input->get_post('iel', TRUE)
                ,'dnextel' =>   $this->input->get_post('dnextel', TRUE)
            );
                $instanceid =  $this->input->get_post('instanceid', TRUE);
            $tplt_plancall= $this->m_tplt_plancall->newRow($instanceid,$data);
            $return = $tplt_plancall;
            print json_encode($return);
    }
    function getRow() {
        log_message('debug', 'TPLT_PLANCALL.getRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $empId  =  $this->input->get_post('id', TRUE);
        if (isset($empId)) {
            $tplt_plancall = $this->m_tplt_plancall->getRow($empId);
            $return = array(
                'success' => true,
                'data'    => $tplt_plancall
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
            	$sort[] = array('property'=>'icall', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
            $instanceid=$this->input->get('instanceid', FALSE);
            if(isset($instanceid)){
                if($instanceid!=''){
                    $tplt_plancall= $this->m_tplt_plancall->getRowsByInstance($instanceid,$sort);
                }else{
                    $tplt_plancall= $this->m_tplt_plancall->getRows($sort);
                }
            }else{
              $tplt_plancall= $this->m_tplt_plancall->getRows($sort);
            }
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tplt_plancall
            );
        print json_encode($return);
    }
    function getRowsByInstance() {
        log_message('debug', 'TPLT_PLANCALL.getRowsByInstance post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'icall', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $InstId  =  $this->input->get_post('instanceid', TRUE);
        if (strlen($InstId) > 0) {
            $tplt_plancall= $this->m_tplt_plancall->getRowsByInstance($InstId,$sort);
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tplt_plancall
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
        log_message('debug', 'TPLT_PLANCALL.getRowsByParent post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'icall', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $ParentId  =  $this->input->get_post('parentid', TRUE);
        if (strlen($ParentId) > 0) {
            $tplt_plancall= $this->m_tplt_plancall->getRowsByParent($ParentId,$sort);
            $return = array(
                'success' => TRUE,
                'data'    => $tplt_plancall
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
        log_message('debug', 'TPLT_PLANCALL.deleteRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $tempId  =  $this->input->get_post('tplt_plancallid', TRUE);
        if (strlen($tempId) > 0) {
            $return = $this->m_tplt_plancall->deleteRow($tempId);
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
        $this->load->model('M_tplt_plancall', 'm_tplt_plancall');
    }
}
?>