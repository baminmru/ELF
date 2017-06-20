<?php
	 class C_tpsrv_modems extends CI_Controller {
    function __construct() {
         parent::__construct();
        $this->_loadModels();
    }
    function setRow() {
          log_message('debug', 'TPSRV_MODEMS.setRow post : '.json_encode($this->input->post(NULL, FALSE)));
          log_message('debug', 'TPSRV_MODEMS.getRows get : '.json_encode($this->input->get(NULL, FALSE)));
          $data = array(
                'tpsrv_modemsid' =>  $this->input->get_post('tpsrv_modemsid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'portnum' =>   $this->input->get_post('portnum', TRUE)
                ,'isusable' =>   $this->input->get_post('isusable', TRUE)
                ,'isused' =>   $this->input->get_post('isused', TRUE)
                ,'useduntil' =>   $this->input->get_post('useduntil', TRUE)
            );
            $tpsrv_modems = $this->m_tpsrv_modems->setRow($data);
            print json_encode($tpsrv_modems);
    }
    function newRow() {
            log_message('debug', 'TPSRV_MODEMS.newRow post : '.json_encode($this->input->post(NULL, FALSE)));
          $data = array(
                'tpsrv_modemsid' =>  $this->input->get_post('tpsrv_modemsid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'portnum' =>   $this->input->get_post('portnum', TRUE)
                ,'isusable' =>   $this->input->get_post('isusable', TRUE)
                ,'isused' =>   $this->input->get_post('isused', TRUE)
                ,'useduntil' =>   $this->input->get_post('useduntil', TRUE)
            );
                $instanceid =  $this->input->get_post('instanceid', TRUE);
            $tpsrv_modems= $this->m_tpsrv_modems->newRow($instanceid,$data);
            $return = $tpsrv_modems;
            print json_encode($return);
    }
    function getRow() {
        log_message('debug', 'TPSRV_MODEMS.getRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $empId  =  $this->input->get_post('id', TRUE);
        if (isset($empId)) {
            $tpsrv_modems = $this->m_tpsrv_modems->getRow($empId);
            $return = array(
                'success' => true,
                'data'    => $tpsrv_modems
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
            	$sort[] = array('property'=>'portnum', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
            $instanceid=$this->input->get('instanceid', FALSE);
            if(isset($instanceid)){
                if($instanceid!=''){
                    $tpsrv_modems= $this->m_tpsrv_modems->getRowsByInstance($instanceid,$sort);
                }else{
                    $tpsrv_modems= $this->m_tpsrv_modems->getRows($sort);
                }
            }else{
              $tpsrv_modems= $this->m_tpsrv_modems->getRows($sort);
            }
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tpsrv_modems
            );
        print json_encode($return);
    }
    function getRowsByInstance() {
        log_message('debug', 'TPSRV_MODEMS.getRowsByInstance post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'portnum', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $InstId  =  $this->input->get_post('instanceid', TRUE);
        if (strlen($InstId) > 0) {
            $tpsrv_modems= $this->m_tpsrv_modems->getRowsByInstance($InstId,$sort);
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tpsrv_modems
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
        log_message('debug', 'TPSRV_MODEMS.getRowsByParent post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'portnum', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $ParentId  =  $this->input->get_post('parentid', TRUE);
        if (strlen($ParentId) > 0) {
            $tpsrv_modems= $this->m_tpsrv_modems->getRowsByParent($ParentId,$sort);
            $return = array(
                'success' => TRUE,
                'data'    => $tpsrv_modems
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
        log_message('debug', 'TPSRV_MODEMS.deleteRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $tempId  =  $this->input->get_post('tpsrv_modemsid', TRUE);
        if (strlen($tempId) > 0) {
            $return = $this->m_tpsrv_modems->deleteRow($tempId);
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
        $this->load->model('M_tpsrv_modems', 'm_tpsrv_modems');
    }
}
?>