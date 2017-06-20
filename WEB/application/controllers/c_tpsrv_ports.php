<?php
	 class C_tpsrv_ports extends CI_Controller {
    function __construct() {
         parent::__construct();
        $this->_loadModels();
    }
    function setRow() {
          log_message('debug', 'TPSRV_PORTS.setRow post : '.json_encode($this->input->post(NULL, FALSE)));
          log_message('debug', 'TPSRV_PORTS.getRows get : '.json_encode($this->input->get(NULL, FALSE)));
          $data = array(
                'tpsrv_portsid' =>  $this->input->get_post('tpsrv_portsid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'portname' =>   $this->input->get_post('portname', TRUE)
                ,'isusable' =>   $this->input->get_post('isusable', TRUE)
                ,'isused' =>   $this->input->get_post('isused', TRUE)
                ,'useduntil' =>   $this->input->get_post('useduntil', TRUE)
            );
            $tpsrv_ports = $this->m_tpsrv_ports->setRow($data);
            print json_encode($tpsrv_ports);
    }
    function newRow() {
            log_message('debug', 'TPSRV_PORTS.newRow post : '.json_encode($this->input->post(NULL, FALSE)));
          $data = array(
                'tpsrv_portsid' =>  $this->input->get_post('tpsrv_portsid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'portname' =>   $this->input->get_post('portname', TRUE)
                ,'isusable' =>   $this->input->get_post('isusable', TRUE)
                ,'isused' =>   $this->input->get_post('isused', TRUE)
                ,'useduntil' =>   $this->input->get_post('useduntil', TRUE)
            );
                $instanceid =  $this->input->get_post('instanceid', TRUE);
            $tpsrv_ports= $this->m_tpsrv_ports->newRow($instanceid,$data);
            $return = $tpsrv_ports;
            print json_encode($return);
    }
    function getRow() {
        log_message('debug', 'TPSRV_PORTS.getRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $empId  =  $this->input->get_post('id', TRUE);
        if (isset($empId)) {
            $tpsrv_ports = $this->m_tpsrv_ports->getRow($empId);
            $return = array(
                'success' => true,
                'data'    => $tpsrv_ports
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
            	$sort[] = array('property'=>'portname', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
            $instanceid=$this->input->get('instanceid', FALSE);
            if(isset($instanceid)){
                if($instanceid!=''){
                    $tpsrv_ports= $this->m_tpsrv_ports->getRowsByInstance($instanceid,$sort);
                }else{
                    $tpsrv_ports= $this->m_tpsrv_ports->getRows($sort);
                }
            }else{
              $tpsrv_ports= $this->m_tpsrv_ports->getRows($sort);
            }
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tpsrv_ports
            );
        print json_encode($return);
    }
    function getRowsByInstance() {
        log_message('debug', 'TPSRV_PORTS.getRowsByInstance post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'portname', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $InstId  =  $this->input->get_post('instanceid', TRUE);
        if (strlen($InstId) > 0) {
            $tpsrv_ports= $this->m_tpsrv_ports->getRowsByInstance($InstId,$sort);
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tpsrv_ports
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
        log_message('debug', 'TPSRV_PORTS.getRowsByParent post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'portname', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $ParentId  =  $this->input->get_post('parentid', TRUE);
        if (strlen($ParentId) > 0) {
            $tpsrv_ports= $this->m_tpsrv_ports->getRowsByParent($ParentId,$sort);
            $return = array(
                'success' => TRUE,
                'data'    => $tpsrv_ports
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
        log_message('debug', 'TPSRV_PORTS.deleteRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $tempId  =  $this->input->get_post('tpsrv_portsid', TRUE);
        if (strlen($tempId) > 0) {
            $return = $this->m_tpsrv_ports->deleteRow($tempId);
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
        $this->load->model('M_tpsrv_ports', 'm_tpsrv_ports');
    }
}
?>